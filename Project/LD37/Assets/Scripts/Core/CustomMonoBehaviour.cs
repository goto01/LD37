using Assets.Scripts.Controllers;
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

        #endregion
    }
}
