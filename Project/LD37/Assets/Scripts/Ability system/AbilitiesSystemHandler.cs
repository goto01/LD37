using System.Collections.Generic;
using Assets.Scripts.Ability_system.Abilities;
using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.Ability_system
{
    class AbilitiesSystemHandler : CustomMonoBehaviour
    {
        #region Fields

        [Space]
        [Space]
        [SerializeField] private List<AbilityBase> _abilities;
        [SerializeField] private int _currentAbilityIndex;

        #endregion

        #region Properties

        public AbilityBase CurrentAbility { get { return _abilities[_currentAbilityIndex]; } }

        #endregion

        #region Unity events

        protected virtual void Update()
        {
            SwitchAbility(_movementController.GetAbilitySwitchDelta());
        }

        #endregion

        #region Private methods

        private void SwitchAbility(int delta)
        {
            if (delta == 0) return;
            CurrentAbility.Unselect();
            _currentAbilityIndex += delta;
            Debug.Log(_currentAbilityIndex);
            _currentAbilityIndex %= _abilities.Count;
            if (_currentAbilityIndex < 0) _currentAbilityIndex = _abilities.Count - 1;
            CurrentAbility.Select();
        }

        #endregion
    }
}
