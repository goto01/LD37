using UnityEngine;

namespace Assets.Scripts.Core.Depended
{
    class PositionDependedComponent : CustomMonoBehaviour
    {
        #region Fields

        [Space]
        [Space]
        [SerializeField] private Transform _target;
        [SerializeField] private Vector2 _offset;

        #endregion

        #region Unity events

        protected virtual void OnEnable()
        {
            UpdatePosition();
        }

        protected virtual void Update()
        {
            UpdatePosition();
        }

        #endregion

        #region Private methods

        private void UpdatePosition()
        {
            var position = transform.position;
            position.x = _target.position.x;
            position.y = _target.position.y;
            position += (Vector3)_offset;
            transform.position = position;
        }

        #endregion
    }
}
