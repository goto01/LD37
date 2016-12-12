using UnityEngine;

namespace Assets.BulletSpawner
{
    class SimpleBulletSpawner : BulletSpawner
    {
        protected override Vector2 Way
        {
            get { return Vector2.zero;}
        }
    }
}
