using Assets.Scripts.Core;
using Assets.Scripts.Weapons.MainCharacterWeapons;
using Assets.Scripts.Weapons.WeaponHandler;
using UnityEngine;

namespace Assets.Scripts.Weapons.WeaponPreviews
{
    class WeaponPreview : MonoBehaviour
    {
        #region Fields
        
        private const string ActivatedTrigger = "Activated";
        private const string SelectedTrigger = "Selected";

        [Space] [SerializeField] private CharacterWeaponHandler _weaponHandler;
        [SerializeField] private SimpleMainCharacterGun _gun;
        [SerializeField] private Animator _previewAnimator;
        [SerializeField] private Number _bulletsNumber;

        #endregion

        #region Properties

        private bool IsActivated { get { return _weaponHandler.CheckWeapon(_gun); } }

        private bool IsSelected { get { return _weaponHandler.CurrentWeapon == _gun; } }

        #endregion

        #region Unity events

        protected virtual void Update()
        {
            _previewAnimator.SetBool(ActivatedTrigger, IsActivated);
            _previewAnimator.SetBool(SelectedTrigger, IsSelected);
            _bulletsNumber.UpdateValue(_gun.TotalBulletWithInHolder);
        }

        #endregion
    }
}
