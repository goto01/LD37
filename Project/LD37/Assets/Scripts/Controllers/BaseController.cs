using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class BaseController : MonoBehaviour
    {
        public const string Tag = "CustomGameController";

        protected virtual void Reset()
        {
            gameObject.tag = Tag;
        }
    }
}
