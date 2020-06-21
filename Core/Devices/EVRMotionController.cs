using UnityEngine;
using UnityEngine.XR;

namespace EtherealVR.Input
{
    public class EVRMotionController : MonoBehaviour
    {
        public enum Side
        {
            Left, Right
        }

        public Side side;
        public InputDevice? Device { get; private set; }
        private EVRDevices _devices;
        private Vector3 m_originalPosition;

        private InputDeviceCharacteristics _characteristics = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.TrackedDevice;

        public void Awake()
        {
            _devices = EVRManager.Instance.GetModule<EVRDevices>();

            if (side == Side.Left)
            {
                _characteristics |= InputDeviceCharacteristics.Left;
            }
            else
            {
                _characteristics |= InputDeviceCharacteristics.Right;
            }
        }

        public void Update()
        {
            Device = _devices.GetDeviceByCharacteristics(_characteristics);
        }

        public void LateUpdate()
        {
            if (Device != null)
            {
                transform.position = transform.parent.position + Device.Value.Get(CommonUsages.devicePosition);
                transform.rotation = Device.Value.Get(CommonUsages.deviceRotation);
            }
        }
    }
}