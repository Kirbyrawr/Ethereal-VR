using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace EtherealVR.Input
{
    public static class EVRInputExtendedMethods
    {
        public static float Get(this InputDevice device, InputFeatureUsage<float> usage)
        {
            device.TryGetFeatureValue(usage, out float value);
            return value;
        }

        public static bool Get(this InputDevice device, InputFeatureUsage<bool> usage)
        {
            device.TryGetFeatureValue(usage, out bool value);
            return value;
        }

        public static Vector2 Get(this InputDevice device, InputFeatureUsage<Vector2> usage)
        {
            device.TryGetFeatureValue(usage, out Vector2 value);
            return value;
        }

        public static Vector3 Get(this InputDevice device, InputFeatureUsage<Vector3> usage)
        {
            device.TryGetFeatureValue(usage, out Vector3 value);
            return value;
        }

        public static Quaternion Get(this InputDevice device, InputFeatureUsage<Quaternion> usage)
        {
            device.TryGetFeatureValue(usage, out Quaternion value);
            return value;
        }
    }
}