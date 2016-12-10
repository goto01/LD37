using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.Bullet
{
    public abstract class BulletBase : CustomMonoBehaviour
    {
        #region Fields

        public const string Tag = "Bullet";

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

        protected virtual void Reset()
        {
            gameObject.tag = Tag;
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
            float angle = Mathf.Atan2(way.y, way.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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
