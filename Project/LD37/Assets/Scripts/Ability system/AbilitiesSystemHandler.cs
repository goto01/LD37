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

        #endregion
        
        #region Unity events

        protected virtual void Update()
        {
            SwitchAbility(_movementController.GetAbilityIndex());
        }

        #endregion

        #region Private methods

        private void SwitchAbility(int index)
        {
            if (index < 0) return;
            var activatedAbiluty = _movementController.GetAbilityIndex();
            if (activatedAbiluty != -1) _abilities[activatedAbiluty].Activate();
        }

        #endregion
    }
}
