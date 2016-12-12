using System.Collections;
using Assets.Scripts.Bullet;
using Assets.Scripts.MovementComponents;
using UnityEngine;

namespace Assets.Scripts.Ability_system.Abilities
{
    class TailAbility : AbilityBase
    {
        #region Fields

        [SerializeField] private MainCharacter _mainCharacter;
        [SerializeField] private BulletBase _tailBullet;

        #endregion

        #region Overrided methods

        protected override void Activate()
        {
            _mainCharacter.ShowTailPunch();
            _tailBullet.gameObject.SetActive(true);
            StartCoroutine(DeactivateBullet());
            StartCoroutine(Refresh());
        }

        #endregion

        #region Private methods

        private IEnumerator DeactivateBullet()
        {
            yield return new WaitForSeconds(.11f);
            _tailBullet.gameObject.SetActive(false);
            _effectController.MakeBoom(_tailBullet.transform.position);
        }

        #endregion
    }
}
