using System;
using System.Collections;
using System.IO;
using Assets.Scripts.Controllers.SpawnSystem.Spawner;
using Assets.Scripts.EnemiesSpawners;
using UnityEngine;

namespace Assets.Scripts.Controllers.SpawnSystem
{
    class SpawnController : BaseController
    {
        #region Fields

        const string Path = "Resources/wavesconf.json";

        [Space]
        [Space]
        [SerializeField] private EnemySpawnerComponent _spawnerComponent;
        [Space]
        [SerializeField] private Wave _curentWave;
        [Space]
        [SerializeField] private int _waveInfoIndex;
        [SerializeField] private WaveInfo _curentWaveInfo;
        [Space]
        [SerializeField] [Range(0, 1)] private float _timeStep;
        [SerializeField] private float _currentWaveTimeStamp;
        [Space] 
        [SerializeField] private int _enemiesNumber;
        [SerializeField] private int _currentEnemyIndex;
        [Space]
        [SerializeField] private SpawnerInfo _spawner;

        #endregion

        #region Properties

        private float WaveDuration { get { return Time.time - _currentWaveTimeStamp; } }

        #endregion

        #region Unity events

        protected virtual void Awake()
        {
            LoadSpawnerInfo();
            StartCoroutine(StartSpawning());
        }

        //protected virtual void OnDisable()
        //{
        //    var json = JsonUtility.ToJson(_spawner, true);
        //    Debug.Log(json);
        //    if (File.Exists(Path)) File.Delete(Path);
        //    File.Create(Path).Dispose();
        //    var stream = File.CreateText(Path);
        //    stream.Write(json);
        //    stream.Close();
        //}

        #endregion

        #region Private methods

        private IEnumerator StartSpawning()
        {
            _curentWaveInfo = _spawner.GetWaveInfoByIndex(_waveInfoIndex);
            while (true)
            {
                yield return StartCoroutine(StartWave());
                _waveInfoIndex++;
                _curentWaveInfo = _spawner.GetWaveInfoByIndex(_waveInfoIndex);
                yield return new WaitForSeconds(_curentWaveInfo.Delay);
            }
        }

        private IEnumerator StartWave()
        {
            ResetCurrentWave();
            while (_currentEnemyIndex < _enemiesNumber)
            {
                var enemy = GetEnemy();
                if (WaveDuration >= enemy.Delay)
                {
                    _spawnerComponent.Spawn(enemy.EnemyType, enemy.PositionIndex);
                    _currentEnemyIndex++;
                }
                yield return new WaitForSeconds(_timeStep);
            }
        }

        private WaveEnemyItem GetEnemy()
        {
            return _curentWave.GetEnemyByIndex(_currentEnemyIndex);
        }

        private void ResetCurrentWave()
        {
            _currentWaveTimeStamp = Time.time;
            _curentWave = GetWaveById(_curentWaveInfo.WaveId);
            _enemiesNumber = _curentWave.EnemiesCount;
            _currentEnemyIndex = 0;
        }

        private Wave GetWaveById(string id)
        {
            return _spawner.GetWaveById(id);
        }

        private void LoadSpawnerInfo()
        {
            var text = File.ReadAllText(Path);
            try
            {
                _spawner = JsonUtility.FromJson<SpawnerInfo>(text);
            }
            catch (ArgumentException e)
            {
                Debug.Log(e.Message);
            }
        }

        #endregion
    }
}
