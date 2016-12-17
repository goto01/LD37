using System.Collections;
using System.Diagnostics;
using Assets.Scripts.MovementComponents;
using Assets.Scripts.Weapons.WeaponHandler;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Controllers
{
    class GameOverController : BaseController
    {
        #region Fields

        private string DieTrigger = "Die";
        private string SlowSwitchTrigger = "SlowSwitch";

        [SerializeField] private LevelConfigurationController _configurationController;
        [SerializeField] private Dam _dam;
        [SerializeField] private CharacterWeaponHandler _weaponHandler;
        [SerializeField] private MainCharacter _mainCharacter;
        [SerializeField] private Animator _imageAnimator;
        [SerializeField] private GameObject _game;
        [SerializeField] private GameObject _gameOverImage;

        private bool _waitingForClick;

        #endregion

        protected virtual void Update()
        {
            if (_waitingForClick && Input.GetMouseButtonDown(0)) SceneManager.LoadScene(1); 
            if (_configurationController.CurrentCharacterHealth  < 1 || _dam.CurrentHealth < 1) StartCoroutine(InvokeGameOver());
        }

        private IEnumerator InvokeGameOver()
        {
            _imageAnimator.SetTrigger(SlowSwitchTrigger);
            _mainCharacter.CharacterStop = true;
            _weaponHandler.gameObject.SetActive(false);
            yield return new WaitForSeconds(2);
            _game.SetActive(false);
            _gameOverImage.SetActive(true);
            _waitingForClick = true;
        }
    }
}
