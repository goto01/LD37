using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public abstract class BaseWeapon : CustomMonoBehaviour
    {
        #region Fields

        [Space]
        [Space]
        [SerializeField] private BulletSpawner.BulletSpawner _spawner;
        
        #endregion

        #region Properties

        protected abstract bool IsShotTime { get; }

        #endregion

        #region Unity events

        protected virtual void FixedUpdate()
        {
            if (IsShotTime) MakeShot();
        }

        #endregion

        #region Protected methods

        protected virtual void MakeShot(float maxDistance = 1, float angle = 0)
        {
            _spawner.MakeShot(default(Vector2), maxDistance, angle);
        }

        #endregion
    }
}
