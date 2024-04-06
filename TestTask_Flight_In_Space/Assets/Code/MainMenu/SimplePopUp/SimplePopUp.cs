using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Services.ScreenServiceSpace;

namespace Code.MainMenu
{
    public class SimplePopUp : AbstractScreen<PopUpModel>
    {
        [SerializeField] protected PopUpButton[] _buttons;
        [SerializeField] protected Button _closeButton;
        [SerializeField] protected TMP_Text _headerText;

        public override void Dispose()
        {
            foreach (PopUpButton btn in _buttons)
                btn.Dispose();

            _closeButton.onClick.RemoveAllListeners();
        }

        protected override void OnBind(PopUpModel model)
        {
            BindCloseButton(model);
            BindHeaderText(model);
            BindButtons(model);
        }

        private void BindCloseButton(PopUpModel model) => 
            _closeButton.onClick.AddListener(model.Close);

        private void BindHeaderText(PopUpModel model) => 
            _headerText.text = model.MessageText;

        private void BindButtons(PopUpModel model)
        {
            for (var i = 0; i < _buttons.Length; i++)
            {
                if (model.Binds.Length > i)
                    BindButton(_buttons[i], model.Binds[i], model);
                else
                    DisableButton(_buttons[i]);
            }
        }

        private void BindButton(PopUpButton button, PopUpButtonBind buttonBind, PopUpModel model)
        {
            button.gameObject.SetActive(true);
            button.Init(buttonBind.Text, () =>
            {
                buttonBind.OnClick?.Invoke();
                model.Close();
            });
        }

        private void DisableButton(PopUpButton button) => 
            button.gameObject.SetActive(false);
    }
}