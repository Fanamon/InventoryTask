using System.Collections.Generic;
using UnityEngine;

public class ItemTypeButtonsObserver : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private InventoryView _inventoryView;
    [SerializeField] private List<ItemTypeSelectorButton> _buttons;

    private void OnEnable()
    {
        _inventory.InventoryChanged += OnInventoryChanged;

        foreach (var button in _buttons)
        {
            button.Clicked += OnClicked;
        }
    }

    private void OnDisable()
    {
        _inventory.InventoryChanged -= OnInventoryChanged;

        foreach (var button in _buttons)
        {
            button.Clicked -= OnClicked;
        }
    }

    private void OnClicked(ItemType itemType)
    {
        _inventoryView.Render(_inventory.GetSortedItemsByType(itemType));
    }

    private void OnInventoryChanged(IEnumerable<KeyValuePair<AssetItem, int>> inventory)
    {
        _inventoryView.Render(inventory);
    }
}
