using Assets.Scripts.Ability_system.Abilities;
using UnityEngine;

namespace Assets.Scripts.Ability_system
{
    class AbilityPreview : MonoBehaviour
    {
        #region Fields

        private const string ProgressParameter = "_Progress";

        [Space]
        [Space]
        [SerializeField] private AbilityBase _ability;
        [Space]
        [Space]
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite _idleSprite;
        [SerializeField] private Sprite _selectedSprite;

        #endregion

        #region Unity events

        protected virtual void Update()
        {
            _spriteRenderer.material.SetFloat(ProgressParameter, _ability.RefreshLerpDelta);
            if (_ability.Selected) _spriteRenderer.sprite = _selectedSprite;
            else _spriteRenderer.sprite = _idleSprite;
        }

        #endregion
    }
}
