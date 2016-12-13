using System;
using UnityEngine;

namespace Assets.Scripts.Controllers.SpawnSystem.Spawner
{
    [Serializable]
    class WaveInfo
    {
        #region Fields

        [SerializeField] private float _delay;
        [SerializeField] private string _waveId;

        #endregion

        #region Properties

        public float Delay { get { return _delay; } }

        public string WaveId { get { return _waveId; } }

        #endregion
    }
}
