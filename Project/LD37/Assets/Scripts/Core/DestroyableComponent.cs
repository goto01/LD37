using UnityEngine;

namespace Assets.Scripts.Core
{
    class DestroyableComponent : MonoBehaviour
    {
        public void DestroyMyself()
        {
            gameObject.SetActive(false);
        }
    }
}
