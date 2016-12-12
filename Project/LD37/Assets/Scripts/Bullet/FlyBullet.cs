using Assets.Scripts.MovementComponents.Enemies;
using UnityEngine;

namespace Assets.Scripts.Bullet
{
    class FlyBullet : BulletBase
    {
        protected override Vector2 Offset
        {
            get { return Vector2.zero;}
        }

        protected override void UpdatePosition()
        {
        }

        protected override void CheckForColision()
        {
        }

        protected override void DestroyIfOutOfBorder()
        {
        }

        protected virtual void OnTriggerStay2D(Collider2D collider)
        {
            var enemy = collider.GetComponent<SimpleEnemy>();
            enemy.MakeDamage();
            enemy.Push(_way);
            _effectController.MakeSparks(enemy.transform.position);
        }
    }
}
