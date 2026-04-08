using VContainer;

namespace Core.Interfaces
{
    /// <summary>
    /// A modular registration unit for VContainer.
    /// Decouples the main <see cref="VContainer.Unity.LifetimeScope"/> from feature-specific dependency logic.
    /// </summary>
    public interface IInstaller
    {
        void Install(IContainerBuilder builder);
    }
}