using System;
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

        #region Public methods

        public virtual void MakeShot(float maxDistance = 1, float angle = 0)
        {
            var way = Way;
            if (Math.Abs(angle) > .001) way = Quaternion.Euler(0, 0, angle)*way; 
            var bullet = _pool.PopObject<BulletBase>();
            bullet.InitBullet(transform.position, way, maxDistance);
        }

        #endregion
    }
}
