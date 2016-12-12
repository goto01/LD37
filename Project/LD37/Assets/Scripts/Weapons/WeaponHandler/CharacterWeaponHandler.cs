using System.Collections.Generic;
using Assets.Scripts.Core;
using Assets.Scripts.Weapons.MainCharacterWeapons;
using UnityEngine;

namespace Assets.Scripts.Weapons.WeaponHandler
{
    class CharacterWeaponHandler : CustomMonoBehaviour
    {
        #region Fields

        private const string ReloadedParameter = "Reloaded";
        private const string BulletRanOutParameter = "BulletRanOut";

        [Space]
        [Space]
        [SerializeField] private List<SimpleMainCharacterGun> _weapons; 
        [SerializeField] private int _currentWeaponIndex;
        [Space]
        [Space]
        [SerializeField] private Animator _cursor;

        #endregion

        #region Properties

        private int CurrentWeaponIndex
        {
            get { return _currentWeaponIndex; }
            set
            {
                if (_currentWeaponIndex == value) return;
                _weapons[_currentWeaponIndex].gameObject.SetActive(false);
                _currentWeaponIndex = value;
                _currentWeaponIndex %= _weapons.Count;
                if (_currentWeaponIndex == -1) _currentWeaponIndex = _weapons.Count - 1;
                _weapons[_currentWeaponIndex].gameObject.SetActive(true);
            }
        }

        public SimpleMainCharacterGun CurrentWeapon { get { return _weapons[_currentWeaponIndex]; } }

        #endregion

        #region Public methods

        public bool CheckWeapon(SimpleMainCharacterGun weapon)
        {
            return _weapons.Contains(weapon);
        }

        #endregion

        #region Unity events

        protected virtual void Update()
        {
            CurrentWeaponIndex -= _movementController.GetScroll();
            _cursor.SetBool(ReloadedParameter, CurrentWeapon.Reloaded);
            _cursor.SetBool(BulletRanOutParameter, CurrentWeapon.IsBulletsInHolderRanOut && CurrentWeapon.IsBulletsRanOut);
        }

        #endregion

        public void IncBullets()
        {
            _weapons.ForEach(x=>x.IncBullets());
        }
    }
}
