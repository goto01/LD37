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
        [SerializeField] private bool _selected;
        [SerializeField] protected bool _activated;

        #endregion

        #region Properties

        public bool IsActivated { get { return _selected && !_refreshing && _movementController.CheckAbilityEvent(); } } 

        public bool Selected { get { return _selected; } }

        public float RefreshLerpDelta { get { return Mathf.InverseLerp(0, _refreshTime, _currentRefreshTime); } }

        #endregion

        #region Unity events

        protected virtual void Start()
        {
            _currentRefreshTime = _refreshTime;
        }

        protected virtual void Update()
        {
            if (IsActivated)
            {
                _activated = true;
                Activate();
            }
        }

        #endregion

        #region Public methods

        public void Unselect()
        {
            _selected = false;
        }

        public void Select()
        {
            _selected = true;
        }

        #endregion

        #region Protected methods

        protected abstract void Activate();

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
