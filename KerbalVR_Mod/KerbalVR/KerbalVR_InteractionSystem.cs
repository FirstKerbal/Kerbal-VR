using UnityEngine;
using Valve.VR;

namespace KerbalVR
{
    /// <summary>
    /// InteractionSystem is a singleton class that encapsulates
    /// the code that manages interaction systems via SteamVR_Input,
    /// i.e. the interaction game objects (hands), and input actions.
    /// </summary>
    public class InteractionSystem : MonoBehaviour
    {
        #region Singleton
        /// <summary>
        /// This is a singleton class, and there must be exactly one GameObject with this Component in the scene.
        /// </summary>
        private static InteractionSystem _instance;
        public static InteractionSystem Instance {
            get {
                if (_instance == null) {
                    _instance = FindObjectOfType<InteractionSystem>();
                    if (_instance == null) {
                        Utils.LogError("The scene needs to have one active GameObject with an InteractionSystem script attached!");
                    } else {
                        _instance.Initialize();
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// One-time initialization for this singleton class.
        /// </summary>
        private void Initialize() {
            // load glove prefab assets
            glovePrefabL = AssetLoader.Instance.GetGameObject("vr_glove_left_model_slim");
            if (glovePrefabL == null) {
                Utils.LogWarning("Could not load prefab: vr_glove_left_model_slim");
                return;
            }
            glovePrefabR = AssetLoader.Instance.GetGameObject("vr_glove_right_model_slim");
            if (glovePrefabR == null) {
                Utils.LogWarning("Could not load prefab: vr_glove_right_model_slim");
                return;
            }
        }
        #endregion


        #region Properties
        public GameObject LeftHand { get; private set; }
        public GameObject RightHand { get; private set; }
        //public GameObject HeadUpDisplay { get; private set; }
        #endregion


        #region Private Members
        // hand game objects
        protected GameObject glovePrefabL;
        protected GameObject glovePrefabR;
        protected KerbalVR.Hand handScriptL, handScriptR;

        // head up display
        protected KerbalVR.HeadUpDisplay hud;

        // device behaviors and actions
        protected bool isHandsInitialized = false;
        protected SteamVR_Action_Pose handActionPose;
        protected SteamVR_Action_Boolean teleportAction;
        protected SteamVR_Action_Boolean headsetOnAction;

        // teleport system
        protected GameObject teleportSystemGameObject;
        protected TeleportSystem teleportSystem;
        #endregion


        protected void Update() {
            // initialize hand scripts (need OpenVR and SteamVR_Input already initialized)
            if (!isHandsInitialized && KerbalVR.Core.IsOpenVrReady) {
                InitializeHandScripts();
                isHandsInitialized = true;
            }
            if (!isHandsInitialized) {
                return;
            }

            // position the teleport system
            if (HighLogic.LoadedScene == GameScenes.MAINMENU) {
                teleportSystem.downwardsVector = Vector3.down;
            }
            else if (HighLogic.LoadedScene == GameScenes.FLIGHT && FlightGlobals.ActiveVessel != null) {
                // assign the teleport system's down vector to point towards gravity
                CelestialBody mainBody = FlightGlobals.ActiveVessel.mainBody;
                Vector2d latLon = mainBody.GetLatitudeAndLongitude(teleportSystemGameObject.transform.position);
                teleportSystem.downwardsVector = -mainBody.GetSurfaceNVector(latLon.x, latLon.y);
            }
        }

        protected void InitializeHandScripts() {
            // store actions for these devices
            handActionPose = SteamVR_Input.GetPoseAction("default", "Pose");
            headsetOnAction = SteamVR_Input.GetBooleanAction("default", "HeadsetOnHead");
            headsetOnAction.onChange += OnChangeHeadsetOnAction;
            teleportAction = SteamVR_Input.GetBooleanAction("EVA", "Teleport");

            // set up the hand objects
            LeftHand = new GameObject("KVR_HandL");
            DontDestroyOnLoad(LeftHand);
            handScriptL = LeftHand.AddComponent<KerbalVR.Hand>();
            handScriptL.handPrefab = glovePrefabL;
            handScriptL.handType = SteamVR_Input_Sources.LeftHand;
            handScriptL.handActionPose = handActionPose;

            RightHand = new GameObject("KVR_HandR");
            DontDestroyOnLoad(RightHand);
            handScriptR = RightHand.AddComponent<KerbalVR.Hand>();
            handScriptR.handPrefab = glovePrefabR;
            handScriptR.handType = SteamVR_Input_Sources.RightHand;
            handScriptR.handActionPose = handActionPose;

            handScriptR.otherHand = LeftHand;
            handScriptL.otherHand = RightHand;

            // can init the skeleton behavior now
            handScriptL.Initialize();
            handScriptR.Initialize();

            // init the teleport system
            teleportSystemGameObject = new GameObject("KVR_TeleportSystem");
            teleportSystem = teleportSystemGameObject.AddComponent<TeleportSystem>();
            teleportSystem.handOriginLeft = LeftHand.transform;
            teleportSystem.handOriginRight = RightHand.transform;
            DontDestroyOnLoad(teleportSystemGameObject);

            // init the head up display
            //HeadUpDisplay = new GameObject("KVR_HeadUpDisplay");
            //DontDestroyOnLoad(HeadUpDisplay);
            //hud = HeadUpDisplay.AddComponent<KerbalVR.HeadUpDisplay>();
            //hud.Initialize();
        }

        /// <summary>
        /// Activate or deactivate VR when the headset is worn or not, respectively.
        /// </summary
        /// <param name="fromAction">The HeadsetOnHead action</param>
        /// <param name="fromSource">The source for the event</param>
        /// <param name="newState">True if the headset is being worn by the user, false otherwise</param>
        protected void OnChangeHeadsetOnAction(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool newState) {
            KerbalVR.Core.IsVrEnabled = newState;
        }

    } // class InteractionSystem
} // namespace KerbalVR
