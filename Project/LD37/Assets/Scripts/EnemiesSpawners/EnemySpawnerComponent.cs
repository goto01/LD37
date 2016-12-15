using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Core;
using Assets.Scripts.Core.Pull;
using Assets.Scripts.MovementComponents.Enemies;
using UnityEngine;

namespace Assets.Scripts.EnemiesSpawners
{
    class EnemySpawnerComponent : CustomMonoBehaviour
    {
        #region Fields

        [SerializeField] private List<PortablePool> _pools; 

        #endregion

        #region Public methods

        public void Spawn(int enemyType, int positionIndex)
        {
            var angle = _circleController.GetAngleByPositionIndex(positionIndex);
            var enemy = _pools[enemyType].PopDeactivatedOject<SimpleEnemy>();
            enemy.Angle = angle;
            _effectController.MakeBlackHole(_circleController.GetCoordsByAngle(angle));
            StartCoroutine(ActivateEnemy(enemy.gameObject));
        }

        #endregion

        #region Private methods

        private IEnumerator ActivateEnemy(GameObject @object)
        {
            yield return new WaitForSeconds(.7f);
            @object.SetActive(true);
        }

        #endregion
    }
}
