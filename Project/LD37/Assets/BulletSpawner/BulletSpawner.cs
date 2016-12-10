using Assets.Scripts.Bullet;
using Assets.Scripts.Core;
using Assets.Scripts.Core.Pull;
using UnityEngine;

namespace Assets.BulletSpawner
{
    public abstract class BulletSpawner : CustomMonoBehaviour
    {
        #region Fields

        [Space]
        [Space]
        [SerializeField]
        private PortablePool _pool;

        #endregion

        #region Properties

        abstract protected Vector2 Way { get; }

        #endregion

        #region Protected methods

        protected void MakeShot()
        {
            var bullet = _pool.PopObject<BulletBase>();
            bullet.InitBullet(transform.position, Way);
        }

        #endregion
    }
}
