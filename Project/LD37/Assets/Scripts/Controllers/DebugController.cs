﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Controllers
{
    class DebugController : BaseController
    {
        #region Fields

        [Space]
        [Space]
        [SerializeField] private GameObject _timer;
        [SerializeField] private GameObject _debugWindow;
        [SerializeField] private GameObject _music;

        #endregion

        #region Unity events

        protected virtual void Awake()
        {
            if (PreviewController.Debug)
            {
                _timer.SetActive(false);
                _debugWindow.SetActive(true);
                _music.SetActive(false);
            }
            else
            {
                _timer.SetActive(true);
                _debugWindow.SetActive(false);
                _music.SetActive(true);
            }
        }

        #endregion
    }
}
