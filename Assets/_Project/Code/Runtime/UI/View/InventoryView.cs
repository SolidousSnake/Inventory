using System;
using System.Collections.Generic;
using _Project.Code.Runtime.Gameplay.Inventory;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Code.Runtime.UI.View
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private ItemSlotView _itemSlotViewPrefab;
        [SerializeField] private RectTransform _contentPanel;
        [SerializeField] private Button _showButton;
        [SerializeField] private Button _closeButton;
        
        private readonly List<ItemSlotView> _slotViewList = new();

        private Inventory _inventory;

        public event Action<int> SlotWasClicked;

        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);

        public void Initialize(int size, Inventory inventory)
        {
            _inventory = inventory;
            _inventory.InventoryUpdated += UpdateUI;
            _showButton.OnClickAsObservable().Subscribe(_ => Show()).AddTo(this);
            _closeButton.OnClickAsObservable().Subscribe(_ => Hide()).AddTo(this);
            
            for (int i = 0; i < size; i++)
            {
                ItemSlotView slotView = Instantiate(_itemSlotViewPrefab, _contentPanel);
                _slotViewList.Add(slotView);
                slotView.Clicked += HandleClick;
            }
        }

        private void HandleClick(int index)
        {
            SlotWasClicked?.Invoke(index);
        }

        private void UpdateUI()
        {
            var items = _inventory.GetItems();

            for (int i = 0; i < _slotViewList.Count; i++)
            {
                if (i < items.Count)
                    _slotViewList[i].SetData(items[i].ItemConfig.Icon, items[i].Quantity, i);
                else
                    _slotViewList[i].Clear();
            }
        }

        private void OnDestroy() => _inventory.InventoryUpdated -= UpdateUI;
    }
}