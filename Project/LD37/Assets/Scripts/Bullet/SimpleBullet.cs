using UnityEngine;

namespace Assets.Scripts.Bullet
{
    class SimpleBullet : BulletBase
    {
        protected override Vector2 Offset { get { return _levelConfigurationController.MainCharacterBulletSpeed * _way.normalized;} }

        protected override void UpdatePosition()
        {
            transform.position += (Vector3)Offset;
        }
    }
}
