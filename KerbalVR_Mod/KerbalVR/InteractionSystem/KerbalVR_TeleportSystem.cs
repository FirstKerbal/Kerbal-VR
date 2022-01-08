using UnityEngine;
using Valve.VR;

namespace KerbalVR {
    public class TeleportSystem : MonoBehaviour
    {
        public Vector3 downwardsVector = Vector3.down;
        public Transform handOriginLeft, handOriginRight;
        public float maxForwardCastDistance = 10f;
        public float maxDownwardCastDistance = 10f;
        public float teleportArcPeriod = 0.125f;

        public float bezierControlPointAngleDeg = 40f;
        public float bezierControlPointFraction = 0.75f;

        /// <summary>
        /// True if teleportation is allowed in the current scene, false otherwise.
        /// </summary>
        private bool _isTeleportAllowed = false;
        public bool IsTeleportAllowed {
            get {
                if (KerbalVR.Core.IsVrRunning) {
                    switch (HighLogic.LoadedScene) {
                        case GameScenes.MAINMENU:
                        case GameScenes.EDITOR:
                            _isTeleportAllowed = true;
                            break;

                        case GameScenes.FLIGHT:
                            if (KerbalVR.Scene.IsInEVA()) {
                                _isTeleportAllowed = true;
                            }
                            else {
                                _isTeleportAllowed = false;
                            }
                            break;
                    }
                } else {
                    _isTeleportAllowed = false;
                }
                return _isTeleportAllowed;
            }
        }

        protected Transform origin;
        protected SteamVR_Action_Boolean teleportAction;
        protected SteamVR_Input_Sources teleportSource = SteamVR_Input_Sources.Any;
        protected bool isTeleportShowing = false;
        protected bool isTeleportTargetValid = false;
        protected Vector3 teleportTargetPosition = Vector3.zero;
        protected Quaternion teleportTargetRotation = Quaternion.identity;
        protected GameObject teleportLocationModel;

        protected const int MAX_TELEPORT_ARC_VERTICES = 10;
        protected const float TELEPORT_ARC_FRACTION = 1f / MAX_TELEPORT_ARC_VERTICES;
        protected LineRenderer[] teleportArcVertexRenderers = new LineRenderer[MAX_TELEPORT_ARC_VERTICES];

        protected void Awake() {
            teleportAction = SteamVR_Input.GetBooleanAction("EVA", "Teleport");

            for (int i = 0; i < MAX_TELEPORT_ARC_VERTICES; ++i) {
                GameObject arcVertex = new GameObject("KVR_TeleportArcVertex_" + i);
                teleportArcVertexRenderers[i] = arcVertex.AddComponent<LineRenderer>();
                teleportArcVertexRenderers[i].material = new Material(Shader.Find("Particles/Standard Unlit"));
                teleportArcVertexRenderers[i].startColor = teleportArcVertexRenderers[i].endColor = Color.cyan;
                teleportArcVertexRenderers[i].startWidth = teleportArcVertexRenderers[i].endWidth = 0.02f;
                teleportArcVertexRenderers[i].enabled = false;
                DontDestroyOnLoad(arcVertex);
            }

            GameObject teleportLocationPrefab = KerbalVR.AssetLoader.Instance.GetGameObject("KVR_TeleportPoint");
            teleportLocationModel = Instantiate(teleportLocationPrefab);
            teleportLocationModel.name = "KVR_TeleportPoint";
            teleportLocationModel.SetActive(false);
            DontDestroyOnLoad(teleportLocationModel);
        }

        protected void OnEnable() {
            teleportAction.AddOnChangeListener(OnTeleportActionChangeL, SteamVR_Input_Sources.LeftHand);
            teleportAction.AddOnChangeListener(OnTeleportActionChangeR, SteamVR_Input_Sources.RightHand);
        }

        protected void OnDisable() {
            teleportAction.RemoveOnChangeListener(OnTeleportActionChangeL, SteamVR_Input_Sources.LeftHand);
            teleportAction.RemoveOnChangeListener(OnTeleportActionChangeR, SteamVR_Input_Sources.RightHand);
        }

        protected void Update() {
            // position the teleportation origin
            if (origin != null) {
                this.transform.position = origin.transform.position;
                this.transform.rotation = origin.transform.rotation;
            }

            // calculate the teleportation target
            UpdateTeleportTarget();

            // render the teleport arc
            RenderTeleportArc();
        }

        protected void OnTeleportActionChangeL(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool newState) {
            OnTeleportActionChange(fromAction, fromSource, newState);
        }
        protected void OnTeleportActionChangeR(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool newState) {
            OnTeleportActionChange(fromAction, fromSource, newState);
        }

        protected void OnTeleportActionChange(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool newState) {
            if (teleportSource == SteamVR_Input_Sources.Any || teleportSource == fromSource) {
                if (newState) {
                    // button has been pressed down, when the teleport arc wasn't already showing.
                    // switch the origin to the controller that pressed the button.
                    if (fromSource == SteamVR_Input_Sources.RightHand) {
                        teleportSource = SteamVR_Input_Sources.RightHand;
                        origin = handOriginRight;
                        isTeleportShowing = true;
                    }
                    else if (fromSource == SteamVR_Input_Sources.LeftHand) {
                        teleportSource = SteamVR_Input_Sources.LeftHand;
                        origin = handOriginLeft;
                        isTeleportShowing = true;
                    }
                }
                else {
                    // button has been lifted, move to that location
                    if (IsTeleportAllowed && isTeleportTargetValid) {
#if false
                        Vector3 hmdPosition = KerbalVR.Scene.Instance.HmdTransform.pos;
                        Vector3 newPlayerPosition = teleportTargetPosition - new Vector3(hmdPosition.x, 0f, hmdPosition.z);
                        if (HighLogic.LoadedScene == GameScenes.FLIGHT && FlightGlobals.ActiveVessel != null) {
                            FlightGlobals.ActiveVessel.SetPosition(newPlayerPosition);
                        }
                        else if (HighLogic.LoadedScene == GameScenes.MAINMENU) {
                            KerbalVR.Scene.Instance.CurrentPosition = newPlayerPosition;
                        }
#endif
                    }
                    teleportSource = SteamVR_Input_Sources.Any;
                    isTeleportShowing = false;
                }
            }
        }

        protected void UpdateTeleportTarget() {
            isTeleportTargetValid = false;
            if (IsTeleportAllowed && isTeleportShowing && origin != null) {
                // raycasts should not strike layer "Scaled Scenery"
                // TODO: identify other layers to not strike
                int layerMask = 1 << 10;
                layerMask = ~layerMask;

                // cast a ray forward
                RaycastHit forwardHit;
                Vector3 forwardVector = origin.TransformDirection(Vector3.forward);
                if (Physics.Raycast(origin.position, forwardVector, out forwardHit, maxForwardCastDistance, layerMask)) {
                    teleportTargetPosition = forwardHit.point;
                    teleportTargetRotation = Quaternion.LookRotation(
                        Vector3.ProjectOnPlane(teleportTargetPosition - origin.position, forwardHit.normal), forwardHit.normal);
                    isTeleportTargetValid = true;
                }
                else {
                    // shorten the max forward cast distance when the controller starts to pitch high up,
                    // so the teleport location starts to come closer faster
                    float pitchAngle = Vector3.Angle(forwardVector, downwardsVector);
                    float pitchAngleNorm = MathUtils.Map(pitchAngle, 90f, 180f, 1f, 0.01f);
                    float forwardCastDistance = maxForwardCastDistance * pitchAngleNorm;
                    Vector3 maxForwardCastPosition = forwardVector * forwardCastDistance + origin.position;

                    // cast a ray downward
                    RaycastHit downwardHit;
                    if (Physics.Raycast(maxForwardCastPosition, downwardsVector, out downwardHit, maxDownwardCastDistance, layerMask)) {
                        teleportTargetPosition = downwardHit.point;
                        teleportTargetRotation = Quaternion.LookRotation(
                            Vector3.ProjectOnPlane(teleportTargetPosition - origin.position, downwardHit.normal), downwardHit.normal);
                        isTeleportTargetValid = true;
                    }
                }
            }
        }

        protected void RenderTeleportArc() {
            if (IsTeleportAllowed && isTeleportShowing && isTeleportTargetValid && origin != null) {
                // determine the bezier control point
                // TODO: maybe increase the lift angle at very high controller pitches
                Vector3 targetFromOrigin = teleportTargetPosition - origin.position;
                Vector3 bezierControlFromOrigin = (teleportTargetPosition - origin.position) * bezierControlPointFraction;
                Vector3 rotationAxis = Vector3.Cross(targetFromOrigin, downwardsVector);
                bezierControlFromOrigin = Quaternion.AngleAxis(-bezierControlPointAngleDeg, rotationAxis) * bezierControlFromOrigin;

                // generate bezier vertices along curve
                Vector3 startPoint = origin.position;
                Vector3 controlPoint = bezierControlFromOrigin + origin.position;
                Vector3 endPoint = teleportTargetPosition;

                for (int i = 0; i < MAX_TELEPORT_ARC_VERTICES; i++) {
                    // bezier vertex point
                    float t = (TELEPORT_ARC_FRACTION * i) + (Time.time % teleportArcPeriod) / teleportArcPeriod * TELEPORT_ARC_FRACTION;
                    Vector3 pointA = Vector3.Lerp(startPoint, controlPoint, t);
                    Vector3 pointB = Vector3.Lerp(controlPoint, endPoint, t);
                    teleportArcVertexRenderers[i].transform.position = Vector3.Lerp(pointA, pointB, t);

                    // calculate where to start/stop the line renderers
                    Vector3 lrEndPoint = teleportArcVertexRenderers[i].transform.position; // end the line at the current bezier vertex
                    Vector3 lrStartPoint;
                    if (i == 0) {
                        // the first LR will have to start at the origin of the arc
                        lrStartPoint = origin.position;
                    }
                    else {
                        // the next LRs can start at the previous bezier vertex (well, midway there, so it looks like a dashed line)
                        lrStartPoint = Vector3.Lerp(lrEndPoint, teleportArcVertexRenderers[i - 1].transform.position, 0.5f);
                    }
                    teleportArcVertexRenderers[i].SetPosition(0, lrStartPoint);
                    teleportArcVertexRenderers[i].SetPosition(1, lrEndPoint);
                    teleportArcVertexRenderers[i].enabled = true;
                }

                // position the teleport point
                teleportLocationModel.SetActive(true);
                teleportLocationModel.transform.position = teleportTargetPosition;
                teleportLocationModel.transform.rotation = teleportTargetRotation;
            }
            else {
                // turn off arc renderers when teleport is not allowed
                for (int i = 0; i < MAX_TELEPORT_ARC_VERTICES; i++) {
                    teleportArcVertexRenderers[i].enabled = false;
                }
                teleportLocationModel.SetActive(false);
            }
        }
    }
}
