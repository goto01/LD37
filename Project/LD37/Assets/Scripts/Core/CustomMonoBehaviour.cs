using Assets.Scripts.Controllers;
using Assets.Scripts.Controllers.SpawnSystem;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class CustomMonoBehaviour : MonoBehaviour
    {
        #region Fields

        [Space]
        [SerializeField] protected LevelConfigurationController _levelConfigurationController;
        [SerializeField] protected MovementController _movementController;
        [SerializeField] protected CircleController _circleController;
        [SerializeField] protected EffectController _effectController;
        [SerializeField] protected TimeController _timeController;
        [SerializeField] protected SpawnController _SpawnController;
        [SerializeField] protected SoundEffectController _soundEffectController;
        [SerializeField] protected AnalyticsController _analyticsController;

        #endregion
    }
}
