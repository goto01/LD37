using UnityEngine;

namespace Assets.Scripts.MovementComponents.Enemies
{
    class SimpleEnemy : MovementComponent
    {
        public enum Way
        {
            Left = 1,
            Righ = -1,
            Stay = 0,
        }

        #region Fields

        private const string DamageTrigger = "Damage";

        [Space]
        [Space]
        [SerializeField] private int _health;
        [SerializeField] private int _currentHealth;
        [Space]
        [SerializeField]
        private Way _way;

        #endregion

        #region Properties

        private bool IsDead { get { return _currentHealth == 0; } }

        #endregion

        #region Unity events

        protected virtual void OnEnable()
        {
            _currentHealth = _health;
            _effectController.MakeBlackHole(_circleController.GetCoordsByAngle(_angle, _radiusOffset));
        }

        #endregion


        #region Overrided methods

        protected override bool IsMoving
        {
            get { return true; }
        }

        protected override void HandleMovement()
        {
            Translate((int)_way);
        }

        #endregion

        #region Public methods

        public void MakeDamage()
        {
            _currentHealth--;
            if (IsDead) Die();
            UpdateAnimatorDamage();
        }

        public void Push(Vector2 way)
        {
            Debug.DrawLine(transform.position, (Vector2)transform.position + Vector2.Dot(WayForward, way)/WayForward.magnitude * WayForward);
            var proj = Vector2.Dot(WayForward, way)/WayForward.magnitude;
            if (Mathf.Sign(proj) > 0 && _way == Way.Left || Mathf.Sign(proj) < 0 && _way == Way.Righ) _angle += _levelConfigurationController.AngleThrow;
            else if (Mathf.Sign(proj) > 0 && _way == Way.Righ || Mathf.Sign(proj) < 0 && _way == Way.Left) _angle -= _levelConfigurationController.AngleThrow;
        }

        #endregion

        #region Private methods

        private void UpdateAnimatorDamage()
        {
            _animator.SetTrigger(DamageTrigger);
        }

        private void Die()
        {
            _effectController.MakeBoom(transform.position);
            gameObject.SetActive(false);
        }

        #endregion
    }
}
