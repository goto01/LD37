using System;
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
        public const string Tag = "Enemy";

        [Space]
        [Space]
        [SerializeField] private int _health;
        [SerializeField] private int _currentHealth;
        [Space]
        [SerializeField] private bool _hpSpawn;
        [SerializeField] private bool _amoSpawn;
        [Space]
        [SerializeField] private Way _way;

        #endregion

        #region Properties

        private bool IsDead { get { return _currentHealth == 0; } }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        #endregion

        #region Unity events

        protected virtual void OnEnable()
        {
            _SpawnController.EnemiesDead += SpawnControllerOnEnemiesDead;
            _currentHealth = _health;
            UpdatePosition();
        }

        #endregion
        
        #region Overrided methods

        protected override bool IsMoving
        {
            get { return true; }
        }

        protected override void HandleMovement()
        {
            var speedT = _speed;
            _speed *= _levelConfigurationController.EnemiesSpeedDelta;
            Translate((int)_way);
            _speed = speedT;
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
        
        private void SpawnControllerOnEnemiesDead(object sender, EventArgs eventArgs)
        {
            DieInstantly();
        }

        private void UpdateAnimatorDamage()
        {
            _animator.SetTrigger(DamageTrigger);
        }

        private void Die()
        {
            if (_amoSpawn) _levelConfigurationController.SpawnAmo(transform.position);
            if (_hpSpawn) _levelConfigurationController.SpawnHP(transform.position);
            _effectController.MakeBoom(transform.position);
            DieInstantly();
        }

        private void DieInstantly()
        {
            _SpawnController.EnemiesDead -= SpawnControllerOnEnemiesDead;
            _analyticsController.SendEnemyKilledMessage();
            gameObject.SetActive(false);
        }

        #endregion
    }
}
