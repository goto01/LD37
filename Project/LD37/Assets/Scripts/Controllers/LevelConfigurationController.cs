using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Controllers
{
    public class LevelConfigurationController : BaseController
    {
        #region Fields

        [SerializeField] [Range(0, 1)] private float _mainCharacterBulletSpeed;
        [SerializeField] private LayerMask _bulletLayerMask;
        [SerializeField] [Range(0, .5f)] private float _angleThrow;
        [SerializeField] [Range(0, .5f)] private float _mainCharacterAngleThrow;
        [Space]
        [Space]
        [SerializeField] [Range(1, 30)] private int _characterHealth;
        [SerializeField] [Range(1, 30)] private int _currentCharacterHealth;

        #endregion

        #region Properties

        public float MainCharacterBulletSpeed { get { return _mainCharacterBulletSpeed;} }

        public LayerMask _bulletsLayerMask { get { return _bulletLayerMask; } }

        public float AngleThrow { get { return _angleThrow; } }

        public float MainCharacterAngleThrow { get { return _mainCharacterAngleThrow; } }

        public int CharacterHealth { get { return _characterHealth; } }

        public int CurrentCharacterHealth
        {
            get { return _currentCharacterHealth; }
            private set { _currentCharacterHealth = value; }
        }

        #endregion

        #region Events

        public event EventHandler HealthChanged;

        #endregion

        #region Unity events

        protected virtual void Awake()
        {
            ResetCharacterInfo();
        }

        #endregion

        #region Public methods

        public void MakeDamageForMainCharacter(int damage = 1)
        {
            CurrentCharacterHealth -= damage;
            HealthChanged(this, EventArgs.Empty);
        }

        #endregion

        #region Private methods

        private void ResetCharacterInfo()
        {
            _currentCharacterHealth = _characterHealth;
        }

        #endregion
    }
}
