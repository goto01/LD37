using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Analytics;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts.Controllers
{
    public class AnalyticsController : BaseController
    {
        #region Fields

        private string EnemiesKilled = "Enemies killed";

        [SerializeField] private int _maxEnemiesKilledNumber;
        [SerializeField] private int _currentEnemiesKilledNumber;

        #endregion

        #region Unity events

        //protected virtual void Start()
        //{
        //    for (var index = 0; index < 200; index++)
        //    {
        //        Analytics.CustomEvent("test", new Dictionary<string, object>()
        //        {
        //            {"test0", "test value"}
        //        });
        //        Debug.Log("Sent");
        //    }
        //}

        #endregion

        #region Public methods

        public void SendEnemyKilledMessage()
        {
            _currentEnemiesKilledNumber++;
            if (_currentEnemiesKilledNumber >= _maxEnemiesKilledNumber)
            {
                Analytics.CustomEvent(EnemiesKilled, new Dictionary<string, object>()
                {
                    {"number", _currentEnemiesKilledNumber}
                });
                _currentEnemiesKilledNumber = 0;
            }
        }

        #endregion
    }
}
