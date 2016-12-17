using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngineInternal;

namespace Assets.Scripts.Controllers
{
    class PreviewController : BaseController
    {
        #region Fields

        private const string SwitchTrigger = "Switch";

        [Space]
        [Space]
        [SerializeField] private SpriteRenderer _previewSpriteRenderer;
        [SerializeField] private List<Sprite> _sprites;
        [SerializeField] private int _index;
        [Space]
        [SerializeField] private Animator _previewAnimator;
        [SerializeField] private float _switchDelay;
        [Space]
        [SerializeField] private int _nextSceneIndex;

        private static bool _debug;

        #endregion

        #region Properties

        public static bool Debug { get { return _debug; } }

        private Sprite CurrentPreviewSprite { get { return _sprites[_index]; } }

        private int Index
        {
            get { return _index; }
            set
            {
                _index = value;
                SwitchInAnimator();
                if (_index == _sprites.Count) StartCoroutine(SwitchScene());
                _index = Mathf.Clamp(_index, 0, _sprites.Count - 1);
                StartCoroutine(UpdatePreview());
            }
        }

        #endregion

        #region Unity events

        protected virtual void Update()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                _debug = true;
                StartCoroutine(SwitchScene());
            }
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) Index++;
        }

        #endregion

        #region Private methods

        private void SwitchInAnimator()
        {
            _previewAnimator.SetTrigger(SwitchTrigger);
        }

        private IEnumerator SwitchScene()
        {
            yield return new WaitForSeconds(_switchDelay);
            SceneManager.LoadScene(_nextSceneIndex);
        }

        private IEnumerator UpdatePreview()
        {
            yield return new WaitForSeconds(_switchDelay);
            _previewSpriteRenderer.sprite = CurrentPreviewSprite;
        }

        #endregion
    }
}
