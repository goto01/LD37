using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class MovementController : BaseController
    {
        [Flags]
        public enum Control
        {
            Left,
            Right,
            Shoot,
            Punch
        }

        [Serializable]
        class ControlInfo
        {
            [SerializeField] private Control _control;
            [SerializeField] private KeyCode _keyCode;

            public Control Control { get { return _control; } }
            public KeyCode KeyCode { get { return _keyCode; } }
        }

        #region Fields

        [Space]
        [SerializeField] private List<ControlInfo> _controls;

        private IDictionary<Control, KeyCode> _keys;

        #endregion

        #region Unity events

        protected virtual void Awake()
        {
            _keys = new Dictionary<Control, KeyCode>();
            _controls.ForEach(x=>_keys.Add(x.Control, x.KeyCode));
        }

        #endregion

        #region Public methods

        public bool CheckControl(Control control)
        {
            return Input.GetKey(_keys[control]);
        }

        #endregion
    }
}
