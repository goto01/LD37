using Assets.Scripts.Controllers;
using UnityEngine;

namespace Assets.Scripts.Bullet
{
    class SimpleBullet : BulletBase
    {
        #region Fields

        [SerializeField] private int _currentRecochet;

        #endregion

        #region Properties

        protected override Vector2 Offset { get { return _levelConfigurationController.MainCharacterBulletSpeed * _way.normalized;} }

        #endregion

        #region Overrided methods

        public override void InitBullet(Vector2 startPos, Vector2 way, float maxDistance = 1)
        {
            _currentRecochet = 0;
            base.InitBullet(startPos, way, maxDistance);
        }

        protected override void DestroyIfOutOfBorder()
        {
            if (_effectController.Recochet && _circleController.CheckIfBulletOutOfBorder(transform))
            {
                _currentRecochet ++;
                ChangeWay();
            }
            if (!_effectController.Recochet || _currentRecochet > _effectController.RecochetNumber) base.DestroyIfOutOfBorder();
        }

        protected override void UpdatePosition()
        {
            transform.position += (Vector3)Offset;
        }

        #endregion

        #region Private methods

        private void ChangeWay()
        {
            _soundEffectController.PlaySound(SoundEffectController.Sound.BulletDestroy);
            _way = _circleController.GetReflectedVector(_circleController.GetCoordOnCircle(transform.position), _way);
            UpdateRotation();
        }

        #endregion
    }
}
