using GameFlow.Boot;
using VContainer;
using VContainer.Unity;

namespace GameFlow.Scopes
{
    public class BootScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterBuildCallback(r =>
            {
                ExecuteEntryPoint(r);
            });
        }

        private static void ExecuteEntryPoint(IObjectResolver resolver) 
            => resolver.Resolve<EntryPoint>().Execute();
    }
}