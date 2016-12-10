using Assets.Scripts.Controllers;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class CustomMonoBehaviour
    {
        #region Fields

        [Space]
        [SerializeField] private LevelConfigurationController _levelConfigurationController;
        [SerializeField] private MovementController _movementController;

        #endregion
    }
}
