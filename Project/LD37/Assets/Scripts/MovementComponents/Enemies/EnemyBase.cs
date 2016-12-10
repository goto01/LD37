namespace Assets.Scripts.MovementComponents.Enemies
{
    abstract class EnemyBase : MovementComponent
    {
        public enum Way
        {
            Left = 1,
            Righ = -1
        }
    }
}
