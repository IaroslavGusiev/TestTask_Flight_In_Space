using VContainer;
using VContainer.Unity;
using Services.ScreenServiceSpace;
using Code.Infrastructure.StateMachineBase;

namespace Code.MainMenu
{
    public class MainMenuScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<MainMenuBootstrapper>();

            builder
                .Register<MainMenuStateMachine>(Lifetime.Scoped)
                .AsSelf();
            
            builder.Register<StateFactory>(Lifetime.Scoped)
                .AsSelf();

            builder
                .Register<ScreenService>(Lifetime.Scoped)
                .As<IScreenService>();

            builder
                .RegisterComponentInHierarchy<ChildScreensProvider>()
                .As<IScreensProvider>();
        }
    }
}