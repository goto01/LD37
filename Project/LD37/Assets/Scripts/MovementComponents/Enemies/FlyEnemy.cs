using UnityEngine;

namespace Assets.Scripts.MovementComponents.Enemies
{
    class FlyEnemy : SimpleEnemy
    {
        #region Fields

        [SerializeField] private Vector2 Destiation;

        #endregion

        private Vector2 _watToTarget;

        protected override void OnEnable()
        {
            base.OnEnable();
            _watToTarget = (Destiation - (Vector2) transform.position).normalized*.01f;
        }

        protected override void Translate(int delta)
        {
            if (Vector2.Distance(Destiation, transform.position) > .1f) transform.position += (Vector3)_watToTarget;
        }

        protected override void UpdatePosition()
        {
        }
    }
}
