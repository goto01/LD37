using Assets.Scripts.Weapons.WeaponHandler;
using UnityEngine;

namespace Assets.Scripts.Core.Bars
{
    class BulletsBar : CustomMonoBehaviour
    {
        #region Fields

        [Space]
        [Space]
        [SerializeField] private CharacterWeaponHandler _weaponHandler;
        [SerializeField] private TextMesh _textMesh;

        #endregion

        #region Unity events

        protected virtual void Update()
        {
            _textMesh.text = string.Format("Total bullets: {0}\nBullets in holder: {1}/{2}",
                _weaponHandler.CurrentWeapon.TotalBullet, _weaponHandler.CurrentWeapon.CurentBulletsInHolder,
                _weaponHandler.CurrentWeapon.BulletsInHolder);
        }

        #endregion
    }
}
