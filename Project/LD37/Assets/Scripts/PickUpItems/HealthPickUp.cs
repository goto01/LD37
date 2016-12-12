namespace Assets.Scripts.PickUpItems
{
    class HealthPickUp : BasePIckUpItem
    {
        protected override void Handle()
        {
            _levelConfigurationController.AddHealth(5);
        }
    }
}
