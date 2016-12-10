using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core.Pull
{
    class PortablePool : MonoBehaviour
    {
        #region Fields

        [SerializeField] private List<PoolObject> _pool;

        #endregion

        #region Properties

        private PoolObject NextObject
        {
            get
            {
                if (_pool.Count == 0) return null;
                return _pool[0];
            }
        }

        #endregion

        #region Public methods

        public T PopObject<T>() where T:class
        {
            var nextObject = NextObject;
            if (NextObject == null) return null;
            _pool.Remove(nextObject);
            nextObject.gameObject.SetActive(true);
            nextObject.Destroyed += NextObjectOnDestroyed;
            return nextObject.GetComponent<T>();
        }

        private void NextObjectOnDestroyed(object sender, EventArgs eventArgs)
        {
            var pullObject = sender as PoolObject;
            if (pullObject == null) return;
            pullObject.Destroyed -= NextObjectOnDestroyed;
            _pool.Add(pullObject);
        }

        #endregion
    }
}
