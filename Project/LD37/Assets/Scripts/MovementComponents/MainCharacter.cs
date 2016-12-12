using Assets.Scripts.Controllers;
using UnityEngine;

namespace Assets.Scripts.MovementComponents
{
    class MainCharacter : MovementComponent
    {
        #region Fields

        private const string DamageTrigger = "Damage";

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
            PushBack();
            Damage();
        }

        #endregion

        #region Private methods

        private void PushBack()
        {
            if (transform.localScale.x < 0) _angle += _levelConfigurationController.MainCharacterAngleThrow;
            else _angle -= _levelConfigurationController.MainCharacterAngleThrow;
        }

        public void ShowDamage()
        {
            _animator.SetTrigger(DamageTrigger);
            _effectController.Shake();
        }

        public void Damage()
        {
            _levelConfigurationController.MakeDamageForMainCharacter();
            ShowDamage();
        }

        #endregion
    }
}
