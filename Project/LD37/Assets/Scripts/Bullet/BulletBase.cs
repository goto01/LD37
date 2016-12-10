using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.Bullet
{
    public abstract class BulletBase : CustomMonoBehaviour
    {
        #region Fields

        [Space]
        [Space]
        [SerializeField] protected Vector2 _way;

        #endregion

        #region Unity events

        protected virtual void FixedUpdate()
        {
            UpdatePosition();
            DestroyIfOutOfBorder();
        }

        #endregion

        #region Public methods

        public void InitBullet(Vector2 startPos, Vector2 way)
        {
            var position = transform.position;
            position.x = startPos.x;
            position.y = startPos.y;
            transform.position = position;
            _way = way;
        }

        #endregion

        #region Astract methods

        abstract protected void UpdatePosition();

        #endregion

        #region Protected methods

        protected virtual void DestroyIfOutOfBorder()
        {
            if (_circleController.CheckIfObjectOutOfBorder(transform)) gameObject.SetActive(false);
        }

        #endregion
    }
}
