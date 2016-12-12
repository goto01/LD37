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

        public override void MakeShot(float maxDistance = 1, float angle = 0)
        {
            _effectController.Shake();
            _animator.SetTrigger(BoomTrigger);
            base.MakeShot(maxDistance, angle);
        }
    }
}
