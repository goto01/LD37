using Assets.Scripts.Controllers;

namespace Assets.Scripts.MovementComponents
{
    class MainCharacter : MovementComponent
    {
        #region Override 

        protected override void HandleMovement()
        {
            if (_movementController.CheckControl(MovementController.Control.Left)) Translate(-1);
            else if (_movementController.CheckControl(MovementController.Control.Right)) Translate(1);
        }

        #endregion
    }
}
