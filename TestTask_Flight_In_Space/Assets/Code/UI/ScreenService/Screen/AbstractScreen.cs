using System;

namespace Services.ScreenServiceSpace
{
    public abstract class AbstractScreen<TModel> : BaseScreen where TModel : IUiModel
    {
        public override Type ModelType => typeof(TModel);
        private TModel _model;

        public override void Show()
        {
            _model.OnShow();
            gameObject.SetActive(true);
        }

        public override void Close()
        {
            _model.OnClose();
            gameObject.SetActive(false);
        }

        public override void Bind(object model)
        {
            if (model is TModel uiModel)
                Bind(uiModel);
        }

        protected abstract void OnBind(TModel model);

        private void Bind(TModel model)
        {
            _model = model;
            OnBind(model);
        }
    }
}