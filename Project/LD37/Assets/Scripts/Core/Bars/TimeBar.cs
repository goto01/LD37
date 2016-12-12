using UnityEngine;

namespace Assets.Scripts.Core.Bars
{
    class TimeBar : CustomMonoBehaviour
    {
        #region Fields

        [Space]
        [Space]
        [SerializeField] private Number _secods;
        [SerializeField] private Number _milliSeconds;

        #endregion

        #region Unity events

        protected virtual void Update()
        {
            _secods.UpdateValue(_timeController.Seconds);
            _milliSeconds.UpdateValue(_timeController.Milliseconds);
        }

        #endregion
    }
}
