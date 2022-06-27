//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Valve.VR
{
    using System;
    using UnityEngine;
    
    
    public partial class SteamVR_Actions
    {
        
        private static SteamVR_Action_Boolean p_default_InteractUI;
        
        private static SteamVR_Action_Boolean p_default_GrabGrip;
        
        private static SteamVR_Action_Pose p_default_Pose;
        
        private static SteamVR_Action_Skeleton p_default_SkeletonLeftHand;
        
        private static SteamVR_Action_Skeleton p_default_SkeletonRightHand;
        
        private static SteamVR_Action_Single p_default_Squeeze;
        
        private static SteamVR_Action_Boolean p_default_HeadsetOnHead;
        
        private static SteamVR_Action_Boolean p_default_PinchIndex;
        
        private static SteamVR_Action_Boolean p_default_PinchThumb;
        
        private static SteamVR_Action_Vibration p_default_Haptic;
        
        private static SteamVR_Action_Vector2 p_editor_Move;
        
        private static SteamVR_Action_Boolean p_flight_ToggleRollYaw;
        
        private static SteamVR_Action_Vector2 p_eVA_MoveStick;
        
        private static SteamVR_Action_Vector2 p_eVA_LookStick;
        
        private static SteamVR_Action_Boolean p_eVA_Jump;
        
        private static SteamVR_Action_Boolean p_eVA_ToggleRCS;
        
        private static SteamVR_Action_Single p_eVA_RCSUp;
        
        private static SteamVR_Action_Single p_eVA_RCSDown;
        
        private static SteamVR_Action_Boolean p_eVA_ToggleLight;
        
        private static SteamVR_Action_Boolean p_eVA_Sprint;
        
        private static SteamVR_Action_Boolean p_eVA_SwapRollYaw;
        
        public static SteamVR_Action_Boolean default_InteractUI
        {
            get
            {
                return SteamVR_Actions.p_default_InteractUI.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean default_GrabGrip
        {
            get
            {
                return SteamVR_Actions.p_default_GrabGrip.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Pose default_Pose
        {
            get
            {
                return SteamVR_Actions.p_default_Pose.GetCopy<SteamVR_Action_Pose>();
            }
        }
        
        public static SteamVR_Action_Skeleton default_SkeletonLeftHand
        {
            get
            {
                return SteamVR_Actions.p_default_SkeletonLeftHand.GetCopy<SteamVR_Action_Skeleton>();
            }
        }
        
        public static SteamVR_Action_Skeleton default_SkeletonRightHand
        {
            get
            {
                return SteamVR_Actions.p_default_SkeletonRightHand.GetCopy<SteamVR_Action_Skeleton>();
            }
        }
        
        public static SteamVR_Action_Single default_Squeeze
        {
            get
            {
                return SteamVR_Actions.p_default_Squeeze.GetCopy<SteamVR_Action_Single>();
            }
        }
        
        public static SteamVR_Action_Boolean default_HeadsetOnHead
        {
            get
            {
                return SteamVR_Actions.p_default_HeadsetOnHead.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean default_PinchIndex
        {
            get
            {
                return SteamVR_Actions.p_default_PinchIndex.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean default_PinchThumb
        {
            get
            {
                return SteamVR_Actions.p_default_PinchThumb.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Vibration default_Haptic
        {
            get
            {
                return SteamVR_Actions.p_default_Haptic.GetCopy<SteamVR_Action_Vibration>();
            }
        }
        
        public static SteamVR_Action_Vector2 editor_Move
        {
            get
            {
                return SteamVR_Actions.p_editor_Move.GetCopy<SteamVR_Action_Vector2>();
            }
        }
        
        public static SteamVR_Action_Boolean flight_ToggleRollYaw
        {
            get
            {
                return SteamVR_Actions.p_flight_ToggleRollYaw.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Vector2 eVA_MoveStick
        {
            get
            {
                return SteamVR_Actions.p_eVA_MoveStick.GetCopy<SteamVR_Action_Vector2>();
            }
        }
        
        public static SteamVR_Action_Vector2 eVA_LookStick
        {
            get
            {
                return SteamVR_Actions.p_eVA_LookStick.GetCopy<SteamVR_Action_Vector2>();
            }
        }
        
        public static SteamVR_Action_Boolean eVA_Jump
        {
            get
            {
                return SteamVR_Actions.p_eVA_Jump.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean eVA_ToggleRCS
        {
            get
            {
                return SteamVR_Actions.p_eVA_ToggleRCS.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Single eVA_RCSUp
        {
            get
            {
                return SteamVR_Actions.p_eVA_RCSUp.GetCopy<SteamVR_Action_Single>();
            }
        }
        
        public static SteamVR_Action_Single eVA_RCSDown
        {
            get
            {
                return SteamVR_Actions.p_eVA_RCSDown.GetCopy<SteamVR_Action_Single>();
            }
        }
        
        public static SteamVR_Action_Boolean eVA_ToggleLight
        {
            get
            {
                return SteamVR_Actions.p_eVA_ToggleLight.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean eVA_Sprint
        {
            get
            {
                return SteamVR_Actions.p_eVA_Sprint.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        public static SteamVR_Action_Boolean eVA_SwapRollYaw
        {
            get
            {
                return SteamVR_Actions.p_eVA_SwapRollYaw.GetCopy<SteamVR_Action_Boolean>();
            }
        }
        
        private static void InitializeActionArrays()
        {
            Valve.VR.SteamVR_Input.actions = new Valve.VR.SteamVR_Action[] {
                    SteamVR_Actions.default_InteractUI,
                    SteamVR_Actions.default_GrabGrip,
                    SteamVR_Actions.default_Pose,
                    SteamVR_Actions.default_SkeletonLeftHand,
                    SteamVR_Actions.default_SkeletonRightHand,
                    SteamVR_Actions.default_Squeeze,
                    SteamVR_Actions.default_HeadsetOnHead,
                    SteamVR_Actions.default_PinchIndex,
                    SteamVR_Actions.default_PinchThumb,
                    SteamVR_Actions.default_Haptic,
                    SteamVR_Actions.editor_Move,
                    SteamVR_Actions.flight_ToggleRollYaw,
                    SteamVR_Actions.eVA_MoveStick,
                    SteamVR_Actions.eVA_LookStick,
                    SteamVR_Actions.eVA_Jump,
                    SteamVR_Actions.eVA_ToggleRCS,
                    SteamVR_Actions.eVA_RCSUp,
                    SteamVR_Actions.eVA_RCSDown,
                    SteamVR_Actions.eVA_ToggleLight,
                    SteamVR_Actions.eVA_Sprint,
                    SteamVR_Actions.eVA_SwapRollYaw};
            Valve.VR.SteamVR_Input.actionsIn = new Valve.VR.ISteamVR_Action_In[] {
                    SteamVR_Actions.default_InteractUI,
                    SteamVR_Actions.default_GrabGrip,
                    SteamVR_Actions.default_Pose,
                    SteamVR_Actions.default_SkeletonLeftHand,
                    SteamVR_Actions.default_SkeletonRightHand,
                    SteamVR_Actions.default_Squeeze,
                    SteamVR_Actions.default_HeadsetOnHead,
                    SteamVR_Actions.default_PinchIndex,
                    SteamVR_Actions.default_PinchThumb,
                    SteamVR_Actions.editor_Move,
                    SteamVR_Actions.flight_ToggleRollYaw,
                    SteamVR_Actions.eVA_MoveStick,
                    SteamVR_Actions.eVA_LookStick,
                    SteamVR_Actions.eVA_Jump,
                    SteamVR_Actions.eVA_ToggleRCS,
                    SteamVR_Actions.eVA_RCSUp,
                    SteamVR_Actions.eVA_RCSDown,
                    SteamVR_Actions.eVA_ToggleLight,
                    SteamVR_Actions.eVA_Sprint,
                    SteamVR_Actions.eVA_SwapRollYaw};
            Valve.VR.SteamVR_Input.actionsOut = new Valve.VR.ISteamVR_Action_Out[] {
                    SteamVR_Actions.default_Haptic};
            Valve.VR.SteamVR_Input.actionsVibration = new Valve.VR.SteamVR_Action_Vibration[] {
                    SteamVR_Actions.default_Haptic};
            Valve.VR.SteamVR_Input.actionsPose = new Valve.VR.SteamVR_Action_Pose[] {
                    SteamVR_Actions.default_Pose};
            Valve.VR.SteamVR_Input.actionsBoolean = new Valve.VR.SteamVR_Action_Boolean[] {
                    SteamVR_Actions.default_InteractUI,
                    SteamVR_Actions.default_GrabGrip,
                    SteamVR_Actions.default_HeadsetOnHead,
                    SteamVR_Actions.default_PinchIndex,
                    SteamVR_Actions.default_PinchThumb,
                    SteamVR_Actions.flight_ToggleRollYaw,
                    SteamVR_Actions.eVA_Jump,
                    SteamVR_Actions.eVA_ToggleRCS,
                    SteamVR_Actions.eVA_ToggleLight,
                    SteamVR_Actions.eVA_Sprint,
                    SteamVR_Actions.eVA_SwapRollYaw};
            Valve.VR.SteamVR_Input.actionsSingle = new Valve.VR.SteamVR_Action_Single[] {
                    SteamVR_Actions.default_Squeeze,
                    SteamVR_Actions.eVA_RCSUp,
                    SteamVR_Actions.eVA_RCSDown};
            Valve.VR.SteamVR_Input.actionsVector2 = new Valve.VR.SteamVR_Action_Vector2[] {
                    SteamVR_Actions.editor_Move,
                    SteamVR_Actions.eVA_MoveStick,
                    SteamVR_Actions.eVA_LookStick};
            Valve.VR.SteamVR_Input.actionsVector3 = new Valve.VR.SteamVR_Action_Vector3[0];
            Valve.VR.SteamVR_Input.actionsSkeleton = new Valve.VR.SteamVR_Action_Skeleton[] {
                    SteamVR_Actions.default_SkeletonLeftHand,
                    SteamVR_Actions.default_SkeletonRightHand};
            Valve.VR.SteamVR_Input.actionsNonPoseNonSkeletonIn = new Valve.VR.ISteamVR_Action_In[] {
                    SteamVR_Actions.default_InteractUI,
                    SteamVR_Actions.default_GrabGrip,
                    SteamVR_Actions.default_Squeeze,
                    SteamVR_Actions.default_HeadsetOnHead,
                    SteamVR_Actions.default_PinchIndex,
                    SteamVR_Actions.default_PinchThumb,
                    SteamVR_Actions.editor_Move,
                    SteamVR_Actions.flight_ToggleRollYaw,
                    SteamVR_Actions.eVA_MoveStick,
                    SteamVR_Actions.eVA_LookStick,
                    SteamVR_Actions.eVA_Jump,
                    SteamVR_Actions.eVA_ToggleRCS,
                    SteamVR_Actions.eVA_RCSUp,
                    SteamVR_Actions.eVA_RCSDown,
                    SteamVR_Actions.eVA_ToggleLight,
                    SteamVR_Actions.eVA_Sprint,
                    SteamVR_Actions.eVA_SwapRollYaw};
        }
        
        private static void PreInitActions()
        {
            SteamVR_Actions.p_default_InteractUI = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/InteractUI")));
            SteamVR_Actions.p_default_GrabGrip = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/GrabGrip")));
            SteamVR_Actions.p_default_Pose = ((SteamVR_Action_Pose)(SteamVR_Action.Create<SteamVR_Action_Pose>("/actions/default/in/Pose")));
            SteamVR_Actions.p_default_SkeletonLeftHand = ((SteamVR_Action_Skeleton)(SteamVR_Action.Create<SteamVR_Action_Skeleton>("/actions/default/in/SkeletonLeftHand")));
            SteamVR_Actions.p_default_SkeletonRightHand = ((SteamVR_Action_Skeleton)(SteamVR_Action.Create<SteamVR_Action_Skeleton>("/actions/default/in/SkeletonRightHand")));
            SteamVR_Actions.p_default_Squeeze = ((SteamVR_Action_Single)(SteamVR_Action.Create<SteamVR_Action_Single>("/actions/default/in/Squeeze")));
            SteamVR_Actions.p_default_HeadsetOnHead = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/HeadsetOnHead")));
            SteamVR_Actions.p_default_PinchIndex = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/PinchIndex")));
            SteamVR_Actions.p_default_PinchThumb = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/default/in/PinchThumb")));
            SteamVR_Actions.p_default_Haptic = ((SteamVR_Action_Vibration)(SteamVR_Action.Create<SteamVR_Action_Vibration>("/actions/default/out/Haptic")));
            SteamVR_Actions.p_editor_Move = ((SteamVR_Action_Vector2)(SteamVR_Action.Create<SteamVR_Action_Vector2>("/actions/editor/in/Move")));
            SteamVR_Actions.p_flight_ToggleRollYaw = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/flight/in/ToggleRollYaw")));
            SteamVR_Actions.p_eVA_MoveStick = ((SteamVR_Action_Vector2)(SteamVR_Action.Create<SteamVR_Action_Vector2>("/actions/EVA/in/MoveStick")));
            SteamVR_Actions.p_eVA_LookStick = ((SteamVR_Action_Vector2)(SteamVR_Action.Create<SteamVR_Action_Vector2>("/actions/EVA/in/LookStick")));
            SteamVR_Actions.p_eVA_Jump = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/EVA/in/Jump")));
            SteamVR_Actions.p_eVA_ToggleRCS = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/EVA/in/ToggleRCS")));
            SteamVR_Actions.p_eVA_RCSUp = ((SteamVR_Action_Single)(SteamVR_Action.Create<SteamVR_Action_Single>("/actions/EVA/in/RCSUp")));
            SteamVR_Actions.p_eVA_RCSDown = ((SteamVR_Action_Single)(SteamVR_Action.Create<SteamVR_Action_Single>("/actions/EVA/in/RCSDown")));
            SteamVR_Actions.p_eVA_ToggleLight = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/EVA/in/ToggleLight")));
            SteamVR_Actions.p_eVA_Sprint = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/EVA/in/Sprint")));
            SteamVR_Actions.p_eVA_SwapRollYaw = ((SteamVR_Action_Boolean)(SteamVR_Action.Create<SteamVR_Action_Boolean>("/actions/EVA/in/SwapRollYaw")));
        }
    }
}
