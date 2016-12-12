using Assets.Scripts.Core;
using Assets.Scripts.MovementComponents.Enemies;
using UnityEngine;

namespace Assets.Scripts.MovementComponents
{
    class Dam : CustomMonoBehaviour
    {
        #region Fields

        [SerializeField] [Range(10, 2000)] private int _health;
        [SerializeField] [Range(10, 2000)] private int _currentHealth;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        #endregion

        #region Unity events

        protected virtual void OnTriggerStay2D(Collider2D collider)
        {
            if (collider.tag != SimpleEnemy.Tag) return;
            _currentHealth --;
            _spriteRenderer.material.SetFloat("_Progress", Mathf.InverseLerp(0, _health, _currentHealth));
        }

        #endregion
    }
}
