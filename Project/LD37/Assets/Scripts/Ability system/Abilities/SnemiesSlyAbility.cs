using System;
using System.Collections;
using Assets.Scripts.Controllers;
using UnityEngine;

namespace Assets.Scripts.Ability_system.Abilities
{
    class SnemiesSlyAbility : AbilityBase
    {
        [SerializeField] [Range(0, 10)] private float _time;

        protected override void ActivateInstantly()
        {
            _soundEffectController.PlaySound(SoundEffectController.Sound.Slowmo);
            StartCoroutine(Refresh());
            _levelConfigurationController.EnemiesSpeedDelta = .3f;
            StartCoroutine(DisableAbility());
        }

        private IEnumerator DisableAbility()
        {
            yield return new WaitForSeconds(_time);
            _levelConfigurationController.EnemiesSpeedDelta = 1;
        }
    }
}
