using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.MovementComponents.Circle_transform_components
{
    [RequireComponent(typeof(MovementComponent))]
    class SimpleCircleControlComponent : CustomMonoBehaviour
    {
        #region Fields

        private const float AngleOffset = Mathf.PI/2;

        private MovementComponent _movementComponent;

        #endregion

        #region Unity events

        protected virtual void Start()
        {
            _movementComponent = GetComponent<MovementComponent>();
        }

        protected virtual void Update()
        {
            UpdateRotation();
        }

        #endregion

        #region Private methods

        private void UpdateRotation()
        {
            transform.localRotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Rad2Deg * (_movementComponent.Angle + AngleOffset));
            ;
        }

        #endregion
    }
}
