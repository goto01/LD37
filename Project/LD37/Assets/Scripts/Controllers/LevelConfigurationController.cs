using UnityEngine;

namespace Assets.Scripts.Controllers
{
    class LevelConfigurationController : BaseController
    {
        #region Fields

        [Space]
        [SerializeField] private float _circleRadius;

        #endregion

        #region Properties

        public float CircleRadius { get { return _circleRadius; } }

        #endregion
    }
}
