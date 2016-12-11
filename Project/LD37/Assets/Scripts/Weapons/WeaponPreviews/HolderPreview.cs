using Assets.Scripts.Core;
using Assets.Scripts.Weapons.WeaponHandler;
using UnityEngine;

namespace Assets.Scripts.Weapons.WeaponPreviews
{
    class HolderPreview : MonoBehaviour
    {
        #region Fields

        [SerializeField] private CharacterWeaponHandler _weaponHandler;
        [SerializeField] private Number _holderBulletsNumber;
        [SerializeField] private Number _currentHolderBulletsNumber;

        #endregion

        #region Unity events

        protected virtual void Update()
        {
            _holderBulletsNumber.UpdateValue(_weaponHandler.CurrentWeapon.BulletsInHolder);
            _currentHolderBulletsNumber.UpdateValue(_weaponHandler.CurrentWeapon.CurentBulletsInHolder );
        }

        #endregion
    }
}
