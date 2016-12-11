using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core
{
    class Number : MonoBehaviour
    {
        #region Fields

        private const string ValueParameter = "Value";

        [SerializeField] private List<Animator> _animators;
        [SerializeField] private int _number;

        #endregion

        #region Public methods

        public void UpdateValue(int value)
        {
            if (_number == value) return;
            _number = value;
            var index = _animators.Count - 1;
            while (value != 0)
            {
                var n = value%10;
                _animators[index--].SetInteger(ValueParameter, n);
                value /= 10;
            }
            try
            {
                while (index >= 0) _animators[index--].SetInteger(ValueParameter, 0);
            }
            catch (Exception e)
            {
                Debug.Log(name);
                Debug.Log(index);
                Debug.Break();
            }
        }

        #endregion
    }
}
