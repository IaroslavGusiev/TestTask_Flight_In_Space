using Code.UI;
using VContainer;
using UnityEngine;
using Code.Services;
using VContainer.Unity;
using Code.Infrastructure;
using Code.Services.StaticDataService;
using Code.Infrastructure.AnalyticsSpace;
using Code.Infrastructure.StateMachineBase;
using Code.Infrastructure.AppStateMachineScope;

namespace CompositionRoot
{
    public class RootLifetimeScope : LifetimeScope
    {
        [SerializeField] private LoadingCurtain _loadingCurtainPrefab;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<AppBootstrapper>();

            RegisterSceneLoader(builder);
            RegisterStateFactory(builder);
            RegisterAssetProvider(builder);
            RegisterLoadingCurtain(builder);
            RegisterSaveLoadService(builder);
            RegisterAppStateMachine(builder);
            RegisterAnalyticsModule(builder);
            RegisterStaticDataService(builder);
            RegisterPlayerDataProvider(builder);
        }

        private void RegisterSceneLoader(IContainerBuilder builder)
        {
            builder
                .Register<SceneLoader>(Lifetime.Singleton)
                .As<ISceneLoader>();
        }

        private void RegisterStateFactory(IContainerBuilder builder)
        {
            builder
                .Register<StateFactory>(Lifetime.Singleton)
                .AsSelf();
        }

        private void RegisterAssetProvider(IContainerBuilder builder)
        {
            builder
                .Register<AssetProvider>(Lifetime.Singleton)
                .As<IAssetProvider>();
        }

        private void RegisterLoadingCurtain(IContainerBuilder builder)
        {
            builder.RegisterComponentInNewPrefab(_loadingCurtainPrefab, Lifetime.Singleton)
                .DontDestroyOnLoad()
                .As<ILoadingCurtain>();
        }

        private void RegisterSaveLoadService(IContainerBuilder builder)
        {
            builder
                .Register<SaveLoadService>(Lifetime.Singleton)
                .As<ISaveLoadService>();
        }

        private void RegisterAppStateMachine(IContainerBuilder builder)
        {
            builder
                .Register<AppStateMachine>(Lifetime.Singleton)
                .As<IAppStateMachine>()
                .AsSelf();
        }
        
        private void RegisterAnalyticsModule(IContainerBuilder builder)
        {
            builder
                .Register<AnalyticsModule>(Lifetime.Singleton)
                .As<IAnalyticsModule>();
        }

        private void RegisterStaticDataService(IContainerBuilder builder)
        {
            builder
                .Register<StaticDataService>(Lifetime.Singleton)
                .As<IStaticDataService>();
        }

        private void RegisterPlayerDataProvider(IContainerBuilder builder)
        {
            builder
                .Register<PlayerDataProvider>(Lifetime.Singleton)
                .AsSelf();
        }
    }
}