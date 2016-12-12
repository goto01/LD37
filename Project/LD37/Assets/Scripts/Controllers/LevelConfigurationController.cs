using System;
using Assets.Scripts.Core.Pull;
using Assets.Scripts.PickUpItems;
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
        [Space]
        [SerializeField] [Range(0, 1)] private float _enemiesSpeedDelta;
        [Space]
        [SerializeField] private PortablePool _hpPickUps;
        [SerializeField] private PortablePool _amoPickUps;

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

        public float EnemiesSpeedDelta
        {
            get { return _enemiesSpeedDelta; }
            set { _enemiesSpeedDelta = value; }
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

        public void SpawnHP(Vector2 pos)
        {
            _hpPickUps.PopObject<HealthPickUp>().Init(pos);
        }
        
        public void SpawnAmo(Vector2 pos)
        {
            _amoPickUps.PopObject<AmoPickUp>().Init(pos);
        }

        public void MakeDamageForMainCharacter(int damage = 1)
        {
            CurrentCharacterHealth -= damage;
            HealthChanged(this, EventArgs.Empty);
        }

        public void AddHealth(int health)
        {
            _currentCharacterHealth =Mathf.Clamp(_currentCharacterHealth + health, 0, _characterHealth);
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
