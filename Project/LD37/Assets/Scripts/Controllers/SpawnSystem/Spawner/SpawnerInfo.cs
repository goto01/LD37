using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Controllers.SpawnSystem.Spawner
{
    [Serializable]
    class SpawnerInfo
    {
        #region Fields

        [SerializeField] private List<Wave> _waves;
        [SerializeField] private List<WaveInfo> _waveInfos;

        #endregion

        #region Properties

        public int WaveInfosCount { get { return _waveInfos.Count; } }

        #endregion

        #region Public methods

        public WaveInfo GetWaveInfoByIndex(int index)
        {
            index = Mathf.Clamp(index, 0, _waveInfos.Count - 1);
            return _waveInfos[index];
        }

        public Wave GetWaveById(string id)
        {
            return _waves.First(x => x.Id == id);
        }

        #endregion
    }
}
