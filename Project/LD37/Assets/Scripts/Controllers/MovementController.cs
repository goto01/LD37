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
            Right
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
        readonly IDictionary<KeyCode, int> _weapons = new Dictionary<KeyCode, int>()
        {
            {KeyCode.Alpha1, 0 },
            {KeyCode.Alpha2, 1 },
            {KeyCode.Alpha3, 2 },
            {KeyCode.Alpha4, 3 },
        }; 
        readonly IDictionary<KeyCode, int> _abilities = new Dictionary<KeyCode, int>()
        {
            {KeyCode.Q, 0 },
            {KeyCode.W, 1 },
            {KeyCode.E, 2 },
            {KeyCode.R, 3 },
        }; 

        #endregion

        #region Unity events

        protected virtual void Awake()
        {
            _keys = new Dictionary<Control, KeyCode>();
            _controls.ForEach(x=>_keys.Add(x.Control, x.KeyCode));
        }

        protected virtual void Update()
        {
            if (Input.GetKeyDown(KeyCode.P) && Time.timeScale != 0) Time.timeScale = 0;
            else if (Input.GetKeyDown(KeyCode.P)) Time.timeScale = 1;
                Debug.DrawLine(_point, _point + _way);
        }

        #endregion

        #region Public methods

        public bool CheckControl(Control control)
        {
            return Input.GetKey(_keys[control]);
        }

        public bool CheckShootEvent()
        {
            return Input.GetMouseButton(0);
        }

        public bool CheckAbilityEvent()
        {
            return Input.GetMouseButton(1);
        }

        public int GetScroll()
        {
            return Math.Sign(Input.GetAxis("Mouse ScrollWheel"));
        }

        public int GetWeaponIndex()
        {
            foreach (var keyPair in _weapons) if (Input.GetKeyDown(keyPair.Key)) return keyPair.Value;
            return -1;
        }

        public int GetAbilitySwitchDelta()
        {
            if (Input.GetKeyDown(KeyCode.W)) return -1;
            return Input.GetKeyDown(KeyCode.S) ? 1 : 0;
        }

        public int GetAbilityIndex()
        {
            foreach (var keyPair in _abilities) if (Input.GetKeyDown(keyPair.Key)) return keyPair.Value;
            return -1;
        }

        private Vector2 _point;
        private Vector2 _way;
        public Vector2 GetWayToPointer(Vector2 point)
        {
            var way = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - point;
            _way = way;
            _point = point;
            return way;
        }

        #endregion
    }
}
