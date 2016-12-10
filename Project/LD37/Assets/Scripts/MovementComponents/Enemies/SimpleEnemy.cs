using System.Runtime.Remoting.Messaging;
using UnityEngine;

namespace Assets.Scripts.MovementComponents.Enemies
{
    class SimpleEnemy : EnemyBase
    {
        #region Fields

        [Space]
        [SerializeField] private Way _way;

        #endregion

        #region Override 

        protected override bool IsMoving
        {
            get { return true; }
        }

        protected override void HandleMovement()
        {
            Translate((int)_way);
        }

        #endregion
    }
}
