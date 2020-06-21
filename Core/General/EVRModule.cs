using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EtherealVR
{
    public abstract class EVRModule
    {
        protected EVRManager m_manager;
        public abstract void OnDestroy();
    }
}
