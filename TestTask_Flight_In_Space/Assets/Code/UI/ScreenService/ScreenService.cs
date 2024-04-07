using System;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;

namespace Services.ScreenServiceSpace
{
    public class ScreenService : IScreenService
    {
        private readonly IScreensProvider _screensProvider;

        private readonly Dictionary<Type, (BaseScreen screen, IUiModel model)> _shownScreens = new Dictionary<Type, (BaseScreen, IUiModel model)>();
        private readonly Dictionary<Type, IUiModel> _persistentModels = new();
        private Dictionary<Type, BaseScreen> _screensMap;

        public ScreenService(IScreensProvider screensProvider) => 
            _screensProvider = screensProvider;

        public void Init()
        {
            List<BaseScreen> screens = _screensProvider.GetScreens().ToList();
            
            foreach (BaseScreen screen in screens)
                screen.gameObject.SetActive(false);
            
            _screensMap = screens.ToDictionary(e => e.ModelType, e => e);
        }

        public void Show<TModel>() where TModel : BaseViewModel
        {
            if (_screensMap.TryGetValue(typeof(TModel), out BaseScreen screen))
            {
                screen.Show();
                _shownScreens.Add(typeof(TModel), (screen, _persistentModels[typeof(TModel)]));
            }
            else
            {
                Debug.LogError($"No screen for {typeof(TModel).FullName}");
            }
        }

        public void Show<TModel>(TModel model) where TModel : BaseViewModel
        {
            if (_screensMap.TryGetValue(typeof(TModel), out BaseScreen screen))
            {
                model.InjectScreenService(this);
                screen.Bind(model);
                screen.Show();
                _shownScreens.Add(typeof(TModel), (screen, model));
            }
            else
            {
                Debug.LogError($"No screen for {typeof(TModel).FullName}");
            }
        }

        public void Close<TModel>() where TModel: BaseViewModel
        {
            if (_shownScreens.TryGetValue(typeof(TModel), out (BaseScreen screen, IUiModel model) shown))
            {
                shown.screen.Close();
                _shownScreens.Remove(typeof(TModel));
                
                if (shown.model is BaseOneShowModel<TModel>)
                {
                    shown.model.Dispose();
                    shown.screen.Dispose();
                }
            }
            else
            {
                Debug.LogWarning($"No screen shown for {typeof(TModel).FullName}");
            }
        }

        public void BindModel<TModel>(TModel model) where TModel : BaseViewModel
        {
            if (_screensMap.TryGetValue(typeof(TModel), out BaseScreen screen))
            {
                model.InjectScreenService(this);
                screen.Bind(model);
                _persistentModels.Add(typeof(TModel), model);
            }
            else
            {
                Debug.LogError($"No screen for {typeof(TModel).FullName}");
            }
        }
    }
}