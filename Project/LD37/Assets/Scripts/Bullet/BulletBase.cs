using System.Collections.Generic;
using Assets.Scripts.Core;
using Assets.Scripts.MovementComponents.Enemies;
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
        [SerializeField] [Range(0,1f)] protected float _maxDistance;
        [SerializeField] private Vector2 _startPosition;
        [SerializeField] private List<GameObject> _demagedObjects; 

        #endregion

        #region Properties
        
        protected abstract Vector2 Offset { get; }

        #endregion

        #region Unity events

        protected virtual void OnEnable()
        {
            _demagedObjects.Clear();
        }

        protected virtual void FixedUpdate()
        {
            UpdatePosition();
            DestroyIfOutOfBorder();
            CheckForColision();
        }

        protected virtual void Reset()
        {
            gameObject.tag = Tag;
        }

        #endregion

        #region Public methods

        public virtual void InitBullet(Vector2 startPos, Vector2 way, float maxDistance = 1)
        {
            _maxDistance = _circleController.CircleRadius * 2 * maxDistance;
            _startPosition = startPos;
            var position = transform.position;
            position.x = startPos.x;
            position.y = startPos.y;
            transform.position = position;
            _way = way;
            UpdateRotation();
        }

        #endregion

        #region Astract methods

        abstract protected void UpdatePosition();

        #endregion

        #region Protected methods

        protected virtual void DestroyIfOutOfBorder()
        {
            if (Vector2.Distance(transform.position, _startPosition) > _maxDistance) DestroySelf();
            if (_circleController.CheckIfBulletOutOfBorder(transform)) DestroySelf();
        }

        #endregion

        #region Private methods

        private void DestroySelf()
        {
            _effectController.MakeSparks(transform.position);
            gameObject.SetActive(false);
        }

        protected virtual void CheckForColision()
        {
            var hit = Physics2D.Raycast(transform.position, _way, Offset.magnitude, _levelConfigurationController._bulletsLayerMask);
            if (hit.collider != null)
            {
                var enemy = hit.collider.GetComponent<SimpleEnemy>();
                MakeDamage(enemy);
                enemy.Push(_way);
                if (!_effectController.Recochet) gameObject.SetActive(false);
                _effectController.MakeSparks(hit.point);
            }
        }

        private void MakeDamage(SimpleEnemy enemy)
        {
            if (!_demagedObjects.Contains(enemy.gameObject))
            {
                enemy.MakeDamage();
                _demagedObjects.Add(enemy.gameObject);
            }
        }

        protected void UpdateRotation()
        {
            float angle = Mathf.Atan2(_way.y, _way.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        #endregion
    }
}
