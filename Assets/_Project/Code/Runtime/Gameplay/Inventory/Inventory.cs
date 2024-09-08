using System;
using System.Linq;
using System.Collections.Generic;
using _Project.Code.Runtime.Config;
using _Project.Code.Runtime.Data;
using _Project.Code.Runtime.Gameplay.Unit.Facade;
using _Project.Code.Runtime.Services.SaveLoad;
using _Project.Code.Runtime.UI.View;
using UnityEngine;
using Zenject;

namespace _Project.Code.Runtime.Gameplay.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private PlayerFacade _playerFacade;
        [SerializeField] private InventoryConfig _config;
        [SerializeField] private bool _loadSavedData;

        [Inject] private InventoryView _view;
        [Inject] private ISaveLoadService _saveLoadService;

        private readonly List<InventoryItem> _items = new();

        public event Action InventoryUpdated;

        private void Start()
        {
            if (_loadSavedData)
                LoadInventory();

            else
                foreach (var itemConfig in _config.InitialItems)
                    AddItem(itemConfig);
            
            _view.Initialize(_config.MaxSize, this);
            _view.SlotWasClicked += UseItem;

            InventoryUpdated?.Invoke();
        }

        private void OnDisable()
        {
            SaveInventory();
        }

        public List<InventoryItem> GetItems() => _items;

        public void AddItem(ItemConfig itemConfig)
        {
            var existingItems =
                _items.Where(i => i.ItemConfig == itemConfig && i.Quantity < itemConfig.MaxStack).ToList();

            int remainingToAdd = 1;

            foreach (var existingItem in existingItems)
            {
                int availableSpace = itemConfig.MaxStack - existingItem.Quantity;

                if (availableSpace > 0)
                {
                    int toAdd = Mathf.Min(availableSpace, remainingToAdd);
                    existingItem.Quantity += toAdd;
                    remainingToAdd -= toAdd;

                    if (remainingToAdd <= 0)
                        break;
                }
            }

            if (remainingToAdd > 0 && _items.Count < _config.MaxSize)
                _items.Add(new InventoryItem(itemConfig, remainingToAdd));

            InventoryUpdated?.Invoke();
        }

        private void UseItem(int index)
        {
            if (index >= 0 && index < _items.Count)
            {
                ApplyItemEffect(_items[index].ItemConfig);
                _items[index].Quantity--;

                if (_items[index].Quantity <= 0)
                    _items.RemoveAt(index);

                InventoryUpdated?.Invoke();
            }
        }

        private void ApplyItemEffect(ItemConfig itemConfig) => itemConfig.Modifier.Modify(_playerFacade);

        private void SaveInventory()
        {
            var progress = _saveLoadService.Load();
            progress.InventoryItems = _items.Select(i => new InventorySaveData(i.ItemConfig.Name, i.Quantity)).ToList();
            _saveLoadService.Save(progress);
        }

        private void LoadInventory()
        {
            _items.Clear();
            var progress = _saveLoadService.Load();
            foreach (var savedItem in progress.InventoryItems)
            {
                var itemConfig = FindItemConfigByName(savedItem.Name);
                if (itemConfig != null)
                {
                    _items.Add(new InventoryItem(itemConfig, savedItem.Quantity));
                }
            }

            InventoryUpdated?.Invoke();
        }

        private ItemConfig FindItemConfigByName(string itemName) =>
            _config.InitialItems.FirstOrDefault(i => i.Name == itemName);
    }
}