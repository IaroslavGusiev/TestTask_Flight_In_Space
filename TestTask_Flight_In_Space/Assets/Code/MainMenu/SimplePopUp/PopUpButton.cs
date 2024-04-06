using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.MainMenu
{
    public class PopUpButton : MonoBehaviour, IDisposable
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _text;

        public void Init(string text, Action onClick)
        {
            _text.text = text;
            _button.onClick.AddListener(() => onClick?.Invoke());
        }

        public void Dispose() => 
            _button.onClick.RemoveAllListeners();
    }
}