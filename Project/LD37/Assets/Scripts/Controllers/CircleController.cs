using System;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class CircleController : BaseController
    {
        #region Fields

        [Space]
        [SerializeField] private float _circleRadius;
        [SerializeField] private float _circleRadiusBullets;
        [SerializeField] private Vector2 _origin;

        #endregion

        #region Properties

        public float CircleRadius { get { return _circleRadius; } }

        #endregion

        #region Unity events

#if UNITY_EDITOR

        protected virtual void OnDrawGizmos()
        {
            Gizmos.color = new Color(0, 1, 0, .3f);
            Gizmos.DrawSphere(_origin, _circleRadius);
            Gizmos.color = new Color(0, 1, 0, .5f);
            Gizmos.DrawSphere(_origin, .1f);
            Gizmos.color = Color.white;
        }

#endif

        #endregion

        #region Public methods

        public Vector2 GetCoordsByAngle(float angle, float radiusOffset = 0)
        {
            var radius = _circleRadius + radiusOffset;
            return new Vector2(_origin.x + Mathf.Cos(angle)* radius, _origin.y + Mathf.Sin(angle)* radius);
        }

        public float GetAngle(Vector2 pos)
        {
            var minDistance = Vector2.Distance(pos, GetCoordsByAngle(0));
            var resultAngle  = 0f;
            for (var angle = 0f; angle < Mathf.PI*2; angle += .01f)
            {
                var tempPos = GetCoordsByAngle(angle);
                var distance = Vector2.Distance(tempPos, pos);
                if (minDistance > distance)
                {
                    minDistance = distance;
                    resultAngle = angle;
                }
            }
            return resultAngle;
        }

        public bool CheckIfObjectOutOfBorder(Transform transform)
        {
            if (Vector2.Distance(_origin, transform.position) > _circleRadius) return true;
            return false;
        }

        public bool CheckIfBulletOutOfBorder(Transform transform)
        {
            if (Vector2.Distance(_origin, transform.position) > _circleRadiusBullets) return true;
            return false;
        }

        public Vector2 GetCoordOnCircle(Vector2 pos)
        {
            return (pos - _origin).normalized*_circleRadius;
        }

        public Vector2 GetReflectedVector(Vector2 pos, Vector2 way)
        {
            var n = pos - _origin;
            var sign = Math.Sign(Vector3.Cross(way, n).z);
            var angle = Vector2.Angle(way, n);
            return Quaternion.Euler(0, 0, sign * 2 * angle) * (Vector2.zero - way);
        }

        #endregion
    }
}
