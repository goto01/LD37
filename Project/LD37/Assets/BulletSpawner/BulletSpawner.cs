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

        public virtual void MakeShot(Vector2 pos = default (Vector2), float maxDistance = 1, float angle = 0)
        {
            if (pos == default(Vector2)) pos = transform.position;
            var way = Way;
            if (Math.Abs(angle) > .001) way = Quaternion.Euler(0, 0, angle)*way; 
            var bullet = _pool.PopObject<BulletBase>();
            bullet.InitBullet(pos, way, maxDistance);
        }

        #endregion
    }
}
