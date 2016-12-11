using UnityEngine;

namespace Assets.Scripts.Core.Depended
{
    class PositionDependedComponent : CustomMonoBehaviour
    {
        #region Fields

        [Space]
        [Space]
        [SerializeField] private Transform _target;

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
            transform.position = position;
        }

        #endregion
    }
}
