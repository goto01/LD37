using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.PickUpItems
{
    abstract class BasePIckUpItem : CustomMonoBehaviour
    {
        public void Init(Vector2 position)
        {
            Vector3 newPos = position;
            newPos.z = transform.position.z;
            transform.position = newPos;
        }

        #region Unity events

        protected virtual void OnTriggerEnter2D(Collider2D collider2D)
        {
            Handle();
            gameObject.SetActive(false);
        }

        #endregion

        protected abstract void Handle();
    }
}
