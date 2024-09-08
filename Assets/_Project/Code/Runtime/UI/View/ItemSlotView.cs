using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Project.Code.Runtime.UI.View
{
    public class ItemSlotView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private TextMeshProUGUI _quantityTxt;

        private int _index;

        public event Action<int> Clicked;

        public void SetData(Sprite sprite, int quantity, int index)
        {
            _index = index;
            _iconImage.sprite = sprite;
            _quantityTxt.text = $"{quantity}";
        }

        public void OnPointerClick(PointerEventData eventData) => Clicked?.Invoke(_index);

        public void Clear()
        {
            _iconImage.sprite = null;
            _quantityTxt.text = "";
        }
    }
}