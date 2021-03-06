﻿using System.Collections;
using Assets.Scripts.Bullet;
using Assets.Scripts.Controllers;
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

        protected override void ActivateInstantly()
        {
            _soundEffectController.PlaySound(SoundEffectController.Sound.TailAbility);
            _mainCharacter.ShowTailPunch();
            _tailBulletRight.gameObject.SetActive(true);
            _tailBulletLeft.gameObject.SetActive(true);
            StartCoroutine(Refresh());
        }

        #endregion
    }
}
