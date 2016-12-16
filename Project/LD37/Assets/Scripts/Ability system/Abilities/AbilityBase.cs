using System.Collections;
using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.Ability_system.Abilities
{
    abstract class AbilityBase : CustomMonoBehaviour
    {
        #region Fields

        [Space]
        [Space]
        [SerializeField] [Range(.01f, 10)] private float _refreshTime;
        [SerializeField] [Range(.01f, 10)] private float _currentRefreshTime;
        [SerializeField] private bool _refreshing;
        [Space]
        [Space]
        [SerializeField] protected bool _activated;

        #endregion

        #region Properties

        public bool PossibleToActivate { get { return !_refreshing; } } 
        
        public float RefreshLerpDelta { get { return Mathf.InverseLerp(0, _refreshTime, _currentRefreshTime); } }

        #endregion

        #region Unity events

        protected virtual void Start()
        {
            _currentRefreshTime = _refreshTime;
        }

        #endregion

        #region Public methods

        public void Activate()
        {
            if (PossibleToActivate)
            {
                _activated = true;
                ActivateInstantly();
            }
        }

        #endregion

        #region Protected methods

        protected abstract void ActivateInstantly();

        protected IEnumerator Refresh()
        {
            _refreshing = true;
            _currentRefreshTime = 0;
            while (_currentRefreshTime < _refreshTime)
            {
                _currentRefreshTime += Time.deltaTime;
                yield return null;
            }
            _refreshing = false;
        }

        #endregion
    }
}
