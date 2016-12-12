using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class TimeController : BaseController
    {
        #region Fields

        [SerializeField] private float _seconds;

        #endregion

        #region Properties

        public int Seconds { get { return (int) _seconds; } }

        public int Milliseconds { get { return (int)( (_seconds - (int) _seconds)*100); } }

        #endregion

        #region Unity events

        protected virtual void Update()
        {
            _seconds += Time.deltaTime;
        }

        #endregion
    }
}
