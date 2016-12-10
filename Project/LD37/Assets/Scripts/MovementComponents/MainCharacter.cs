using Assets.Scripts.Controllers;

namespace Assets.Scripts.MovementComponents
{
    class MainCharacter : MovementComponent
    {
        #region Properties

        protected override bool IsMoving { get {return _movementController.CheckControl(MovementController.Control.Left)||_movementController.CheckControl(MovementController.Control.Right);} }

        #endregion

        #region Override 

        protected override void HandleMovement()
        {
            if (_movementController.CheckControl(MovementController.Control.Left)) Translate(-1);
            else if (_movementController.CheckControl(MovementController.Control.Right)) Translate(1);
        }

        #endregion
    }
}
