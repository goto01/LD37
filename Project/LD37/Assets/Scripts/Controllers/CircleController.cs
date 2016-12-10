using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class CircleController : BaseController
    {
        #region Fields

        [Space]
        [SerializeField] private float _circleRadius;
        [SerializeField] private Vector2 _origin;

        #endregion

        #region Properties

        public float CircleRadius { get { return _circleRadius; } }

        #endregion

        #region Public methods

        public Vector2 GetCoordsByAngle(float angle, float radiusOffset)
        {
            var radius = _circleRadius + radiusOffset;
            return new Vector2(_origin.x + Mathf.Cos(angle)* radius, _origin.y + Mathf.Sin(angle)* radius);
        }

        #endregion
    }
}
