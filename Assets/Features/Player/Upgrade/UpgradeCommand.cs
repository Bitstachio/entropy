using Core.Interfaces;

namespace Features.Player.Upgrade
{
    public class UpgradeCommand : ICommand
    {
        private readonly IUpgrade _upgrade;
        private readonly float _magnitude;

        public UpgradeCommand(IUpgrade upgrade, float magnitude)
        {
            _upgrade = upgrade;
            _magnitude = magnitude;
        }
        
        public void Execute() => _upgrade.Apply(_magnitude);
    }
}