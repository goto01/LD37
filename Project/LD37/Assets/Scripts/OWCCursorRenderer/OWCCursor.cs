using System;
using UnityEngine;

namespace Assets.Scripts.OWCCursorRenderer
{
    [Serializable]
    public class OWCCursor : ScriptableObject
    {
        #region Fields

        [Space]
        [SerializeField] private Texture2D _texture;
        [SerializeField] private Vector2 _offset;

        #endregion

        #region Properties

        public Texture2D Texture { get { return _texture; } }

        public Vector2 TextureSize { get { return _texture == null ? Vector2.zero : new Vector2(_texture.width, _texture.height); } }

        public Vector2 Offset { get { return _offset; } }

        #endregion
    }
}
