using System;
using System.Collections.Generic;
using UnityEngine;

namespace KerbalVR
{
    public class Types
    {
        // struct to keep track of Camera properties
        public class VRCameraSet {
            public VREyeCamera[] vrCameras;
            public string kspCameraName;
            public Camera kspCameraComponent;
            public bool isInitialized;
        }

        public struct VREyeCamera {
            public GameObject cameraGameObject;
            public Camera cameraComponent;
        }

        public class CameraState {
            public bool enabled;
        }

        /// <summary>
        /// A very simple, basic, generic shift register structure.
        /// Stores values, and detects when values have changed.
        /// </summary>
        /// <typeparam name="T">Any type that implements IEquatable</typeparam>
        public class ShiftRegister<T> where T : IEquatable<T> {
            public List<T> Values { get; private set; }
            private int maxSize;

            public ShiftRegister(uint registerSize) {
                maxSize = (int)registerSize;
                Values = new List<T>(maxSize);
            }

            public void Push(T value) {
                Values.Insert(0, value);

                // delete old items
                for (int i = Values.Count - 1; i > (maxSize - 1); --i) {
                    Values.RemoveAt(i);
                }
            }

            public bool IsChanged() {
                if (Values.Count <= 1) return false;
                return !(Values[1].Equals(Values[0]));
            }
        }
    }
}
