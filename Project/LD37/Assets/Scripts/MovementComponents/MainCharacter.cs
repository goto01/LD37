﻿using Assets.Scripts.Controllers;
using Assets.Scripts.MovementComponents.Enemies;
using UnityEngine;

namespace Assets.Scripts.MovementComponents
{
    class MainCharacter : MovementComponent
    {
        #region Fields

        private const string DamageTrigger = "Damage";
        private const string FlyTrigger = "Fly";
        private const string StopFlyTrigger = "StopFly";
        private const string TailTrigger = "Tail";

        #endregion

        #region Properties

        protected override bool IsMoving { get {return _movementController.CheckControl(MovementController.Control.Left)||_movementController.CheckControl(MovementController.Control.Right);} }

        #endregion

        #region Override 

        protected override void HandleMovement()
        {
            if (_movementController.CheckControl(MovementController.Control.Left)) Translate(-1);
            else if (_movementController.CheckControl(MovementController.Control.Right)) Translate(1);
        }

        #endregion

        #region Unity events
        
        protected virtual void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.tag != SimpleEnemy.Tag) return;
            PushBack();
            Damage();
        }

        #endregion

        #region Public methods

        public void BeginFly()
        {
            _animator.SetTrigger(FlyTrigger);
        }

        public void StopFly()
        {
            _animator.SetTrigger(StopFlyTrigger);
        }

        public void ShowDamage()
        {
            _animator.SetTrigger(DamageTrigger);
            _effectController.Shake();
        }

        public void Damage()
        {
            _soundEffectController.PlaySound(SoundEffectController.Sound.HeroDamaged);
            _levelConfigurationController.MakeDamageForMainCharacter();
            ShowDamage();
        }

        public void ShowTailPunch()
        {
            _animator.SetTrigger(TailTrigger);
        }

        #endregion

        #region Private methods

        private void PushBack()
        {
            if (transform.localScale.x < 0) _angle += _levelConfigurationController.MainCharacterAngleThrow;
            else _angle -= _levelConfigurationController.MainCharacterAngleThrow;
        }

        #endregion
    }
}
