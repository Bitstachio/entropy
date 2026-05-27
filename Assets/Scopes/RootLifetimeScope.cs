using Core.Session;
using VContainer;
using VContainer.Unity;

namespace Scopes
{
    public sealed class RootLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            //----- Sessions -----

            builder.Register<GameSessionData>(Lifetime.Singleton);
        }
    }
}