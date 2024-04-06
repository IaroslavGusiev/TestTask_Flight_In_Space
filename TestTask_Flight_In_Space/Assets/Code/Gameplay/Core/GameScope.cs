using VContainer;
using UnityEngine;
using VContainer.Unity;
using Code.Infrastructure;
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
            RegisterViewportBounds(builder);
            RegisterHittableSpawner(builder);
            RegisterGameStateMachine(builder);
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

        private static void RegisterHittableSpawner(IContainerBuilder builder)
        {
            builder
                .RegisterEntryPoint<HittableSpawner>(Lifetime.Scoped)
                .AsSelf();
        }
    }
}