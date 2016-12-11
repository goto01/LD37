using System.Collections.Generic;
using Assets.Scripts.Core;
using Assets.Scripts.Weapons.MainCharacterWeapons;
using UnityEngine;

namespace Assets.Scripts.Weapons.WeaponHandler
{
    class CharacterWeaponHandler : CustomMonoBehaviour
    {
        #region Fields

        [Space]
        [Space]
        [SerializeField] private List<SimpleMainCharacterGun> _weapons; 
        [SerializeField] private int _currentWeaponIndex;

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

        #endregion

        #region Unity events

        protected virtual void Update()
        {
            CurrentWeaponIndex += _movementController.GetScroll();
        }

        #endregion
    }
}
