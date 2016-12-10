using UnityEngine;

namespace Assets.Scripts.Controllers
{
    class BaseController : MonoBehaviour
    {
        public const string Tag = "CustomGameController";

        protected virtual void Reset()
        {
            Debug.Log("RESET");
            gameObject.tag = Tag;
        }
    }
}
