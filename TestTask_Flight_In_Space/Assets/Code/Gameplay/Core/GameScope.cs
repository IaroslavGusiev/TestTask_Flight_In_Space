using VContainer;
using UnityEngine;
using VContainer.Unity;
using Code.Infrastructure;
using Services.ScreenServiceSpace;
using Code.Services.InputServiceSpace;
using Code.Infrastructure.StateMachineBase;

namespace Code.Gameplay
{
    public class GameScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameBootstrapper>();
            
            RegisterGameFactory(builder);
            RegisterInputService(builder);
            RegisterInputWrapper(builder);
            RegisterStateFactory(builder);
            RegisterScreenService(builder);
            RegisterViewportBounds(builder);
            RegisterHittableSpawner(builder);
            RegisterGameStateMachine(builder);
            RegisterCollisionHitSystem(builder);
        }

        private void RegisterGameFactory(IContainerBuilder builder)
        {
            builder
                .Register<GameFactory>(Lifetime.Scoped)
                .As<IGameFactory>();
        }

        private void RegisterInputService(IContainerBuilder builder)
        {
            if (Application.isEditor)
            {
                builder
                    .Register<EditorInput>(Lifetime.Scoped)
                    .As<IInputService, ITickable>();
            }
            else
            {
                builder
                    .Register<MobileInput>(Lifetime.Scoped)
                    .As<IInputService, ITickable>();
            }
        }

        private void RegisterInputWrapper(IContainerBuilder builder)
        {
            builder
                .RegisterEntryPoint<InputTurnWrapper>(Lifetime.Scoped)
                .AsSelf();
        }

        private void RegisterStateFactory(IContainerBuilder builder)
        {
            builder
                .Register<StateFactory>(Lifetime.Scoped)
                .AsSelf();
        }
        
        private static void RegisterScreenService(IContainerBuilder builder)
        {
            builder
                .Register<ScreenService>(Lifetime.Scoped)
                .As<IScreenService>();

            builder
                .RegisterComponentInHierarchy<ChildScreensProvider>()
                .As<IScreensProvider>();
        }

        private void RegisterViewportBounds(IContainerBuilder builder)
        {
            builder
                .RegisterEntryPoint<ViewportBounds>(Lifetime.Scoped)
                .AsSelf();
        }

        private void RegisterGameStateMachine(IContainerBuilder builder)
        {
            builder
                .Register<GameStateMachine>(Lifetime.Scoped)
                .AsSelf();
        }

        private void RegisterHittableSpawner(IContainerBuilder builder)
        {
            builder
                .RegisterEntryPoint<HittableSpawner>(Lifetime.Scoped)
                .AsSelf();
        }

        private void RegisterCollisionHitSystem(IContainerBuilder builder)
        {
            builder
                .Register<CollisionHitSystem>(Lifetime.Scoped)
                .As<ICollisionHitSystem, IAsyncStartable>()
                .AsSelf();
        }
    }
}