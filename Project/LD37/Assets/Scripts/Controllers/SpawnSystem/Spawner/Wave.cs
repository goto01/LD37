using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers.SpawnSystem.Spawner
{
    [Serializable]
    class Wave
    {
        #region Fields

        [SerializeField] private string _waveId;
        [SerializeField] private List<WaveEnemyItem> _enemies;

        #endregion

        #region Properties

        public string Id { get { return _waveId; } }

        public int EnemiesCount { get { return _enemies.Count; } }

        #endregion

        #region Public methods

        public WaveEnemyItem GetEnemyByIndex(int index)
        {
            return _enemies[index];
        }

        #endregion
    }
}
