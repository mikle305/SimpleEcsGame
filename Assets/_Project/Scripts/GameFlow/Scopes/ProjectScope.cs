using GameFlow.Boot;
using GamePlay.Systems;
using Services.Factories;
using VContainer;
using VContainer.Unity;

namespace GameFlow.Scopes
{
    public class ProjectScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterEntryPoint(builder);
            RegisterEcsSystems(builder);
            RegisterOtherServices(builder);
        }

        private static void RegisterEntryPoint(IContainerBuilder builder) 
            => builder.RegisterEntryPoint<EntryPoint>();

        private static void RegisterEcsSystems(IContainerBuilder builder)
        {
            builder.Register<GameInitSystem>(Lifetime.Singleton);
        }

        private static void RegisterOtherServices(IContainerBuilder builder)
        {
            builder.Register<ObjectActivator>(Lifetime.Singleton);
        }
    }
}