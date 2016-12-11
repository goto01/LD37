using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Core.Bars
{
    class HealthBar : CustomMonoBehaviour
    {
        #region Fields

        private const string ProgressParameter = "_Progress";

        [Space]
        [Space]
        [SerializeField] private Animator _animator;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] [Range(0, 1)] private float _delta;
        [SerializeField] [Range(0, 1)] private float _oldDelta;
        
        #endregion

        #region Properties

        private float HealthDelta
        {
            get
            {
                return Mathf.InverseLerp(0, _levelConfigurationController.CharacterHealth, _levelConfigurationController.CurrentCharacterHealth);
            }
        }

        #endregion

        #region Unity events

        protected virtual void Start()
        {
            _levelConfigurationController.HealthChanged += LevelConfigurationControllerOnHealthChanged;
            _oldDelta = 0;
            _delta = HealthDelta;
            StartCoroutine(Damage());
        }

        private void LevelConfigurationControllerOnHealthChanged(object sender, EventArgs eventArgs)
        {
            _oldDelta = _delta;
            _delta = HealthDelta;
            StartCoroutine(Damage());
        }

        #endregion

        #region Private methods

        private IEnumerator Damage()
        {
            float d = .04f * Math.Sign(_delta - _oldDelta);
            Debug.Log(d);
            while (Math.Abs(_oldDelta - _delta) > .05)
            {
                _oldDelta += d;
                ApplyMaterial(_oldDelta);
                yield return new WaitForSeconds(.01f);
            }
            _oldDelta = _delta;
            ApplyMaterial(_delta);
        }

        private void ApplyMaterial(float delta)
        {
            _spriteRenderer.material.SetFloat(ProgressParameter, delta);
        }

        #endregion
    }
}
