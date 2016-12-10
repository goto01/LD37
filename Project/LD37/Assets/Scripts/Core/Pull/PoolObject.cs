using System;
using UnityEngine;

namespace Assets.Scripts.Core.Pull
{
    class PoolObject : MonoBehaviour
    {
        public event EventHandler Destroyed;

        protected virtual void OnDisable()
        {
            var handler = Destroyed;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}
