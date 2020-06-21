using System.Collections.Generic;
using UnityEngine.XR;

namespace EtherealVR.Input
{
    public class EVRDevices : EVRModule
    {
        public enum DeviceType
        {
            Controller,
            Headset
        }

        public List<InputDevice> devices { get; private set; }

        public EVRDevices(EVRManager manager)
        {
            m_manager = manager;
            Setup();
        }

        private void Setup()
        {
            devices = new List<InputDevice>();
            SubscribeEvents();
            GetCurrentDevices();
        }

        private void SubscribeEvents()
        {
            InputDevices.deviceConnected += OnDeviceConnected;
            InputDevices.deviceDisconnected += OnDeviceDisconnected;
        }

        public void RemoveEvents()
        {
            InputDevices.deviceConnected -= OnDeviceConnected;
            InputDevices.deviceDisconnected -= OnDeviceDisconnected;
        }

        private void GetCurrentDevices()
        {
            List<InputDevice> allDevices = new List<InputDevice>();

            InputDevices.GetDevices(allDevices);

            foreach (InputDevice device in allDevices)
            {
                OnDeviceConnected(device);
            }
        }

        private void OnDeviceConnected(InputDevice device)
        {
            devices.Add(device);
        }

        private void OnDeviceDisconnected(InputDevice device)
        {
            if (devices.Contains(device))
            {
                devices.Remove(device);
            }
        }

        public InputDevice? GetDevice(string name)
        {
            foreach (var device in devices)
            {
                if (device.name == name)
                {
                    return device;
                }
            }

            return null;
        }

        public InputDevice? GetDeviceByCharacteristics(InputDeviceCharacteristics characteristics)
        {
            foreach (var device in devices)
            {
                if (device.characteristics == characteristics)
                {
                    return device;
                }
            }

            return null;
        }

        public override void OnDestroy()
        {
            RemoveEvents();
        }
    }
}