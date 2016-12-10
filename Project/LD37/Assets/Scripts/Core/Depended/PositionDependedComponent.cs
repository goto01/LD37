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

        protected virtual void Update()
        {
            var position = transform.position;
            position.x = _target.position.x;
            position.y = _target.position.y;
            transform.position = position;
        }

        #endregion
    }
}
