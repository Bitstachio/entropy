using Core.Interfaces;

namespace Features.Player.Upgrade
{
    public struct UpgradeOption
    {
        public ICommand Command { get; }
        public UpgradeData Data { get; }

        public UpgradeOption(ICommand command, UpgradeData data)
        {
            Command = command;
            Data = data;
        }
    }
}