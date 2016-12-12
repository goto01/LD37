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
        [SerializeField] private BulletBase _tailBulletRight;
        [SerializeField] private BulletBase _tailBulletLeft;

        #endregion

        #region Overrided methods

        protected override void Activate()
        {
            _mainCharacter.ShowTailPunch();
            _tailBulletRight.gameObject.SetActive(true);
            _tailBulletLeft.gameObject.SetActive(true);
            StartCoroutine(Refresh());
        }

        #endregion
    }
}
