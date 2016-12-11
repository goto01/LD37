using System.Collections;
using Assets.Scripts.Core;
using Assets.Scripts.Core.Pull;
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
                var enemiesNumber = (int)_spawnFunction.Evaluate(Time.time);
                Debug.Log(enemiesNumber);
                yield return new WaitForSeconds(_step);
            }
        }

        #endregion
    }
}
