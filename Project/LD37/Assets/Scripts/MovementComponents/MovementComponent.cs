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
        [SerializeField] protected float _speed;
        [SerializeField] [Range(0,2)] private float _speedDelta = 1;
        [SerializeField] protected float _radiusOffset;
        [SerializeField] protected float _angle;
        [Space]
        [SerializeField] protected Animator _animator;
        [Space]
        [Space]
        //used by animator
        [SerializeField] protected bool _stoped;
        [SerializeField] protected bool _characterStop;

        private Vector2 _prevPoint;

        #endregion

        #region Poperties

        public float Speed { get { return _speed*_speedDelta; }set { _speed = value; } }
        
        public float Angle { get { return _angle; }set { _angle = value; } }

        abstract protected bool IsMoving { get; }

        public Vector2 WayForward { get { return ((Vector2)transform.position - _prevPoint).normalized; } }

        public Vector2 WayBack { get { return ((Vector2)transform.position + _prevPoint).normalized; } }

        public bool CharacterStop
        {
            get { return _characterStop; }
            set { _characterStop = value; }
        }

        #endregion

        #region Unity events

        protected virtual void FixedUpdate ()
        {
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
            if (_stoped || _characterStop) return;
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
            if (_characterStop) return;
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
