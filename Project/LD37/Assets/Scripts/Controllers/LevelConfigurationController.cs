using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class LevelConfigurationController : BaseController
    {
        #region Fields

        [SerializeField] [Range(0, 1)] private float _mainCharacterBulletSpeed;

        #endregion

        #region Properties

        public float MainCharacterBulletSpeed { get { return _mainCharacterBulletSpeed;} }

        #endregion
    }
}
