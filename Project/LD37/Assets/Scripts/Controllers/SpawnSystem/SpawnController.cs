using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Assets.Scripts.Controllers.SpawnSystem.Spawner;
using Assets.Scripts.EnemiesSpawners;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Controllers.SpawnSystem
{
    public class SpawnController : BaseController
    {
        #region Fields

        const string Path = "Resources/";

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
        [Space]
        [Space]
        [SerializeField] private Text _text;
        [SerializeField] private Dropdown _dropdown;

        private List<string> _files;
        private Coroutine _spawningCoroutine;

        #endregion
        
        #region Properties

        private float WaveDuration { get { return Time.time - _currentWaveTimeStamp; } }

        #endregion

        #region Events

        public event EventHandler EnemiesDead;

        #endregion

        #region Unity events

        protected virtual void Awake()
        {
#if UNITY_WEBGL
            StartCoroutine(LoadSpawnerInfo());
            StartCoroutine(StartSpawning());
#elif UNITY_STANDALONE_WIN
            LoadSpawnerInfo();
#endif
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
            UpdateTextInfo();
            _waveInfoIndex = 0;
            _curentWaveInfo = _spawner.GetWaveInfoByIndex(_waveInfoIndex);
            while (true)
            {
                yield return StartCoroutine(StartWave());
                _waveInfoIndex++;
                _curentWaveInfo = _spawner.GetWaveInfoByIndex(_waveInfoIndex);
                UpdateTextInfo();
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



#if UNITY_WEBGL
        private IEnumerator LoadSpawnerInfo()
        {
            var url = Application.dataPath + @"/Configuration/wavesconf.json";
            var request = new WWW(url);
            yield return request;
            _spawner = JsonUtility.FromJson<SpawnerInfo>(request.text);
            StartCoroutine(StartSpawning());
        }
#elif UNITY_STANDALONE_WIN
        private void LoadSpawnerInfo(){

            try
            {
                _files = Directory.GetFiles(Path, "*.json").ToList();
                _dropdown.options = new List<Dropdown.OptionData>();
                _dropdown.AddOptions(_files);
                DropDownChanged();
            }
            catch (Exception e)
            {
                _text.text = "YOU HAVE PROBLEMS IN THE DIRECTORY,\n TRY TO FIX, OR WRITE TO KIRILL";
            }
        }
#endif

        private void UpdateTextInfo()
        {
            _text.text = string.Format("Current WaveInfo index : {0}\nCurrent wave id : {1}", _waveInfoIndex,
                _curentWave.Id);
        }

        private void DropDownChanged()
        {
            try
            {
                var text = File.ReadAllText(_dropdown.options[_dropdown.value].text);
                _spawner = JsonUtility.FromJson<SpawnerInfo>(text);
                _text.text = "FILE PARSED SUCCESSFULLY, YOU CAN BEGIN\n";
                _text.text += string.Format("Waveinfo number: {0}", _spawner.WaveInfosCount);
            }
            catch (ArgumentException e)
            {
                _text.text = "YOU HAVE PROBLEMS IN YOUR JSON FILE,\n TRY TO FIX, OR WRITE TO KIRILL";
            }
        }

        public void BeginSelected()
        {
            StartCoroutine(StartSpawning());
        }

        public void Refresh()
        {
            LoadSpawnerInfo();
        }

        public void KillAllEnemies()
        {
            var handler = EnemiesDead;
            if (handler!=null) handler(this, EventArgs.Empty);
        }

#endregion
    }
}
