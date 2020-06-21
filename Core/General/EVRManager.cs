using System;
using System.Collections.Generic;
using UnityEngine;
using EtherealVR.Input;

namespace EtherealVR
{
    public class EVRManager : MonoBehaviour
    {
        public static EVRManager Instance;
        private Dictionary<Type, EVRModule> m_modules = new Dictionary<Type, EVRModule>();

        private void Awake()
        {
            SetInstance();
            SetupInitialModules();
        }

        private void SetupInitialModules()
        {
            AddModule(new EVRDevices(this));
        }

        private void SetInstance()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        public void AddModule(EVRModule module)
        {
            Type type = module.GetType();
            if (!m_modules.ContainsKey(type))
            {
                m_modules.Add(type, module);
            }
        }

        public T GetModule<T>() where T : EVRModule
        {
            if (m_modules.TryGetValue(typeof(T), out var module))
            {
                return (T)module;
            }

            return null;
        }

        public void RemoveModule<T>() where T : EVRModule
        {
            m_modules.Remove(typeof(T));
        }

        private void OnDestroy()
        {
            foreach (var module in m_modules)
            {
                module.Value.OnDestroy();
            }
        }
    }
}