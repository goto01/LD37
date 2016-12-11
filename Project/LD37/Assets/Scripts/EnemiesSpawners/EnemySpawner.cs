using System.Collections;
using Assets.Scripts.Core;
using Assets.Scripts.Core.Pull;
using Assets.Scripts.MovementComponents;
using Assets.Scripts.MovementComponents.Enemies;
using UnityEngine;

namespace Assets.Scripts.EnemiesSpawners
{
    class EnemySpawner : CustomMonoBehaviour
    {
        #region Fields

        [Space]
        [Space]
        [Space]
        [SerializeField] private PortablePool _enemiesPool;
        [SerializeField] [Range(0, Mathf.PI*2)] private float _startAngle;
        [SerializeField] [Range(0, Mathf.PI*2)] private float _finishAngle;
        [SerializeField] [Range(.001f, .05f)] private float _startedSpeedOfEnemies = .01f;
        [SerializeField] [Range(1, 20)] private int _startedHealthOfEnemies = 5;
        [SerializeField] private AnimationCurve _spawnFunction;
        [SerializeField] [Range(.1f, 1f)] private float _step = 1;
#if UNITY_EDITOR
        [Space]
        [Space]
        [SerializeField] private Color _spawnAreaColor;
        [SerializeField] private bool _showArea;
#endif

    #endregion

        #region Properties

        private Vector2 StartPos { get { return _circleController.GetCoordsByAngle(_startAngle); } }

        private Vector2 FinishPos { get { return _circleController.GetCoordsByAngle(_finishAngle); } }

        private float RandomAngle { get { return Random.Range(_startAngle, _finishAngle); } }

        #endregion

        #region Unity events

#if UNITY_EDITOR

        protected virtual void OnDrawGizmos()
        {
            if (!_showArea) return;
            if (_finishAngle < _startAngle) _finishAngle = _startAngle + .1f;
            Gizmos.color = _spawnAreaColor;
            Gizmos.DrawSphere(StartPos, .2f);
            Gizmos.DrawSphere(FinishPos, .2f);
            var oldPos = StartPos;
            for (var index = 0f; index < 1.1f; index += .1f)
            {
                var newPos = _circleController.GetCoordsByAngle(Mathf.Lerp(_startAngle, _finishAngle, index));
                Gizmos.DrawLine(oldPos, newPos);
                oldPos = newPos;
            }
            Gizmos.color = Color.white;
        }

#endif

        protected virtual void Start()
        {
            StartCoroutine(StartSpawning());
        }

        #endregion

        #region Private methods

        private IEnumerator StartSpawning()
        {
            while (true)
            {
                var enemiesNumber = Mathf.RoundToInt(_spawnFunction.Evaluate(Time.time));
                SpawnEnemies(enemiesNumber);
                yield return new WaitForSeconds(_step);
            }
        }

        private void SpawnEnemies(int number)
        {
            for (var index = 0; index < number; index++)
            {
                var enemy = _enemiesPool.PopDeactivatedOject<SimpleEnemy>();
                var angle = RandomAngle;
                enemy.Angle = angle;
                enemy.Speed = _startedSpeedOfEnemies;
                enemy.Health = _startedHealthOfEnemies;
                _effectController.MakeBlackHole(_circleController.GetCoordsByAngle(angle));
                StartCoroutine(Activate(enemy.gameObject));
            }
        }

        private IEnumerator Activate(GameObject @object)
        {
            yield return new WaitForSeconds(.7f);
            @object.gameObject.SetActive(true);
        }

        #endregion
    }
}
