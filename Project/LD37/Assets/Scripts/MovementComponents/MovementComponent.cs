using Assets.Scripts.Controllers;
using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.MovementComponents
{
    abstract public class MovementComponent : CustomMonoBehaviour
    {
        #region Fields

        private const string RunningParameter = "Running";

        [Space]
        [Space]
        [SerializeField] private float _speed;
        [SerializeField] [Range(0,2)] private float _speedDelta = 1;
        [SerializeField] private float _radiusOffset;
        [SerializeField] protected float _angle;
        [Space]
        [SerializeField] protected Animator _animator;

        private Vector2 _prevPoint;

        #endregion

        #region Poperties

        private float Speed { get { return _speed*_speedDelta; } }
        
        public float Angle { get { return _angle; } }

        abstract protected bool IsMoving { get; }

        public Vector2 WayForward { get { return ((Vector2)transform.position - _prevPoint).normalized; } }

        public Vector2 WayBack { get { return ((Vector2)transform.position + _prevPoint).normalized; } }

        #endregion

        #region Unity events

        void FixedUpdate ()
        {
            //Debug.DrawLine(transform.position, (Vector2)transform.position + WayForward);
            _prevPoint = transform.position;
            HandleMovement();
            UpdatePosition();
            UpdateAnimator();
        }
        
        #endregion

        #region Protected methods

        protected abstract void HandleMovement();
        
        protected void Translate(int delta)
        {
            var sign = Mathf.Sign(delta);
            _angle += Speed*Mathf.Sign(sign);
            var scale = transform.localScale;
            scale.x = .03125f * sign;
            transform.localScale = scale;
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

        private void UpdateAnimator()
        {
            _animator.SetBool(RunningParameter, IsMoving);
        }

        #endregion
    }
}
