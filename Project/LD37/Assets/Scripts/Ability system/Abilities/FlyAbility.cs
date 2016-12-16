using System.Collections;
using Assets.Scripts.Bullet;
using Assets.Scripts.Controllers;
using Assets.Scripts.MovementComponents;
using UnityEngine;

namespace Assets.Scripts.Ability_system.Abilities
{
    class FlyAbility : AbilityBase
    {
        #region Fields

        [SerializeField] private MainCharacter _mainCharacter;
        [SerializeField] [Range(.01f, 2)] private float _speed;
        [SerializeField] private Vector2 _actualSpeed;
        [SerializeField] private BulletBase _bullet;

        #endregion
        
        #region Unity events

        protected virtual void FixedUpdate()
        {
            if (_activated)
            {
                _effectController.MakeBoom(_mainCharacter.transform.position, false);
                _effectController.Shake();
                _mainCharacter.transform.position += (Vector3)_actualSpeed;
                if (_circleController.CheckIfObjectOutOfBorder(_mainCharacter.transform))
                {
                    _mainCharacter.ShowDamage();
                    _mainCharacter.StopFly();
                    _activated = false;
                    _mainCharacter.Angle = _circleController.GetAngle(_mainCharacter.transform.position);
                    _bullet.gameObject.SetActive(true);
                    _bullet.InitBullet(_mainCharacter.transform.position, Vector2.zero, 1);
                    _mainCharacter.CharacterStop = false;
                    StartCoroutine(DisableBullet());
                    _effectController.MakeBoom(_mainCharacter.transform.position);
                }
            }
        }

        #endregion

        #region Overrided methods

        protected override void ActivateInstantly()
        {
            _soundEffectController.PlaySound(SoundEffectController.Sound.FlyAbility);
            StartCoroutine(Refresh());
            _mainCharacter.BeginFly();
            _mainCharacter.CharacterStop = true;
            _actualSpeed = _movementController.GetWayToPointer(_mainCharacter.transform.position).normalized * _speed;
        }

        #endregion

        #region Private methods

        private IEnumerator DisableBullet()
        {
            yield return new WaitForSeconds(.1f);
            _bullet.gameObject.SetActive(false);
        }

        #endregion
    }
}
