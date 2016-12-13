using System;
using UnityEngine;

namespace Assets.Scripts.Controllers.SpawnSystem.Spawner
{
    [Serializable]
    class WaveEnemyItem
    {
        #region Fields

        [SerializeField] private float _delay;
        [SerializeField] private int _enemyType;
        [SerializeField] private int _position;

        #endregion

        #region Properties

        public float Delay { get { return _delay; } }

        public int EnemyType { get { return _enemyType; } }

        public int PositionIndex { get { return _position; } }

        #endregion
    }
}
