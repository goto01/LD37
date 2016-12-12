using Assets.Scripts.Weapons.WeaponHandler;
using UnityEngine;

namespace Assets.Scripts.PickUpItems
{
    class AmoPickUp : BasePIckUpItem
    {
        [SerializeField] private CharacterWeaponHandler _weaponHandler;

        protected override void Handle()
        {
            _weaponHandler.IncBullets();
        }
    }
}
