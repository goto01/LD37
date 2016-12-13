using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.EnemiesSpawners
{
    class EnemySpawnerComponent : CustomMonoBehaviour
    {
        #region Fields



        #endregion

        #region Public methods

        public void Spawn(int enemyType, int positionIndex)
        {
            Debug.LogFormat("enemy type : {0} position index : {1} time {2}", enemyType, positionIndex, Time.time);
            Debug.Break();
        }

        #endregion
    }
}
