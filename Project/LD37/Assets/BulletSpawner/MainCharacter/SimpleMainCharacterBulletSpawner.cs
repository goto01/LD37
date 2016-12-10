using UnityEngine;

namespace Assets.BulletSpawner.MainCharacter
{
    class SimpleMainCharacterBulletSpawner : BulletSpawner
    {
        protected override Vector2 Way
        {
            get { return _movementController.GetWayToPointer(transform.position); }
        }

        protected virtual void FixedUpdate()
        {
            if (_movementController.CheckShootEvent()) MakeShot();
        }
    }
}
