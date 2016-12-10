using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.MovementComponents
{
    public class MovementComponent : CustomMonoBehaviour
    {
        #region Fields

        [Space]
        [Space]
        [SerializeField] private float _speed;
        [SerializeField] [Range(0,2)] private float _speedDelta;
        [SerializeField] private float _angle;

        #endregion

        #region Unity events

        void FixedUpdate () {
	        
        }

        #endregion

        #region Private methods

        private void Translate()
        {
            
        }

        #endregion
    }
}
