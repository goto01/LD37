using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Ability_system.Abilities
{
    class RicochetAbility : AbilityBase
    {
        #region Fields

        [Space]
        [Space]
        [SerializeField] [Range(0, 10)] private float _time;

        #endregion

        #region Overrided methods

        protected override void Activate()
        {
            StartCoroutine(Refresh());
            _effectController.Recochet = true;
            StartCoroutine(DisableRecochet());
        }

        #endregion

        #region Private methods

        private IEnumerator DisableRecochet()
        {
            yield return new WaitForSeconds(_time);
            _effectController.Recochet = false;
        }

        #endregion
    }
}
