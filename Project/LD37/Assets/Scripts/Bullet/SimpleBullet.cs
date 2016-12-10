using UnityEngine;

namespace Assets.Scripts.Bullet
{
    class SimpleBullet : BulletBase
    {
        protected override void UpdatePosition()
        {
            transform.position += (Vector3)(_levelConfigurationController.MainCharacterBulletSpeed * _way);
        }
    }
}
