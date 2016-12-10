using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.MovementComponents
{
    abstract public class MovementComponent : CustomMonoBehaviour
    {
        #region Fields

        [Space]
        [Space]
        [SerializeField] private float _speed;
        [SerializeField] [Range(0,2)] private float _speedDelta;
        [SerializeField] private float _radiusOffset;
        [SerializeField] private float _angle;

        #endregion

        #region Poperties

        private float Speed { get { return _speed*_speedDelta; } }

        #endregion

        #region Unity events

        void FixedUpdate ()
        {
	        HandleMovement();
            UpdatePosition();
        }

        #endregion

        #region Protected methods

        protected abstract void HandleMovement();
        
        protected void Translate(int sign)
        {
            _angle += Speed*Mathf.Sign(sign);
        }

        #endregion

        #region Private methods

        private void UpdatePosition()
        {
            var position = transform.position;
            var newPosition = _circleController.GetCoordsByAngle(_angle, _radiusOffset);
            position.x = newPosition.x;
            position.y = newPosition.y;
            transform.position = position;
        }

        #endregion
    }
}
