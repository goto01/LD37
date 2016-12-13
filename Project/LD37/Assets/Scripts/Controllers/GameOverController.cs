using Assets.Scripts.MovementComponents;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    class GameOverController : BaseController
    {
        #region Fields

        [SerializeField] private LevelConfigurationController _configurationController;
        [SerializeField] private Dam _dam;
        [SerializeField] private Animator _animator;

        #endregion

        protected virtual void Update()
        {
            Debug.Log(_configurationController.CurrentCharacterHealth);
            if (_configurationController.CurrentCharacterHealth  < 1 || _dam.CurrentHealth < 1) _animator.SetTrigger("GAMEOVER");
        }
    }
}
