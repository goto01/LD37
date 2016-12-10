using UnityEngine;

namespace Assets.BulletSpawner.MainCharacter
{
    class SimpleMainCharacterBulletSpawner : BulletSpawner
    {
        #region Fields

        private const string BoomTrigger = "Boom";
        [SerializeField] private Animator _animator;

        #endregion

        protected override Vector2 Way
        {
            get { return _movementController.GetWayToPointer(transform.position); }
        }

        protected virtual void Update()
        {
            if (_movementController.CheckShootEvent())
            {
                _effectController.Shake();
                MakeShot();
                _animator.SetTrigger(BoomTrigger);
            }
        }
    }
}
