using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class LevelConfigurationController : BaseController
    {
        #region Fields

        [SerializeField] [Range(0, 1)] private float _mainCharacterBulletSpeed;
        [SerializeField] private LayerMask _bulletLayerMask;
        [SerializeField] [Range(0, .5f)] private float _angleThrow;

        #endregion

        #region Properties

        public float MainCharacterBulletSpeed { get { return _mainCharacterBulletSpeed;} }

        public LayerMask _bulletsLayerMask { get { return _bulletLayerMask; } }

        public float AngleThrow { get { return _angleThrow; } }

        #endregion
    }
}
