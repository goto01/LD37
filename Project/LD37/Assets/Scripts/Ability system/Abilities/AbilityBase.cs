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
        [SerializeField] private bool _refreshing;
        [Space]
        [Space]
        [SerializeField] private bool _selected;
        [SerializeField] protected bool _activated;

        #endregion

        #region Properties

        private bool IsActivated { get { return _selected && !_refreshing && _movementController.CheckAbilityEvent(); } } 

        #endregion

        #region Unity events

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
            yield return new WaitForSeconds(_refreshTime);
            _refreshing = false;
        }

        #endregion
    }
}
