using Assets.Scripts.Bullet;
using UnityEngine;

namespace Assets.Scripts.MovementComponents.Enemies
{
    abstract class EnemyBase : MovementComponent
    {
        public enum Way
        {
            Left = 1,
            Righ = -1
        }

        #region Fields

        [Space]
        [Space]
        [SerializeField] private int _health;
        [SerializeField] private int _currentHealth;

        #endregion

        #region Properties

        private bool IsDead { get { return _currentHealth == 0; } }

        #endregion

        #region Unity events

        protected virtual void OnEnable()
        {
            _currentHealth = _health;
        }

        protected virtual void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.tag == BulletBase.Tag) _currentHealth--;
            if (IsDead) gameObject.SetActive(false);
        }

        #endregion
    }
}
