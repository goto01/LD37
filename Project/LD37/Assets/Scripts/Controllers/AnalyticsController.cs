using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

namespace Assets.Scripts.Controllers
{
    public class AnalyticsController : BaseController
    {
        #region Fields

        private const string EnemiesKilled = "Enemies killed";
        private const string WaveInfoMessage = "Completed wave";
        private const string DebugModeMessage = "Debug mode";
        private const string LateDebugModeMessage = "Late Debug mode";

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
                Debug.Log(EnemiesKilled);
                _currentEnemiesKilledNumber = 0;
            }
        }

        public void SendWaveInfoMessage(int waveIndex)
        {
            Analytics.CustomEvent(WaveInfoMessage, new Dictionary<string, object>()
            {
                {"index", waveIndex}
            });
            Debug.Log(WaveInfoMessage);
        }

        public void SendDebugModeMessage()
        {
            Analytics.CustomEvent(DebugModeMessage, new Dictionary<string, object>());
            Debug.Log(DebugModeMessage);
            StartCoroutine(SendLateDebugMessage());
        }

        #endregion

        #region Private methods

        private IEnumerator SendLateDebugMessage()
        {
            yield return new WaitForSeconds(60);
            Analytics.CustomEvent(LateDebugModeMessage, new Dictionary<string, object>());
        }

        #endregion
    }
}
