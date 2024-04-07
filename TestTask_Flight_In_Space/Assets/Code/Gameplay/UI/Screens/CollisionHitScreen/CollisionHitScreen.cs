using TMPro;
using UnityEngine;
using Services.ScreenServiceSpace;

namespace Code.Gameplay.UI
{
    public class CollisionHitScreen : AbstractScreen<CollisionHitModel>
    {
        [SerializeField] private TMP_Text _text;
        private CollisionHitModel _model;
        
        protected override void OnBind(CollisionHitModel model)
        {
            _model = model;
            _model.CollisionHitSystem.OnHitAmountChange += ListenToChange;
        }

        private void OnDestroy() => 
            _model.CollisionHitSystem.OnHitAmountChange -= ListenToChange;

        private void ListenToChange() =>
            _text.text = _model.CollisionHitSystem.CurrentHitAmount.ToString();
    }
}