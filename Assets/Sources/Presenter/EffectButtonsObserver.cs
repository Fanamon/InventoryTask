using System.Collections.Generic;
using UnityEngine;

public class EffectButtonsObserver : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private InventoryView _inventoryView;
    [SerializeField] private List<EffectSelectorButton> _buttons;

    private void OnEnable()
    {
        foreach (var button in _buttons)
        {
            button.Clicked += OnClicked;
        }
    }

    private void OnDisable()
    {
        foreach (var button in _buttons)
        {
            button.Clicked -= OnClicked;
        }
    }

    private void OnClicked(Effect effect)
    {
        _inventoryView.Render(_inventory.GetSortedItemByEffect(effect));
    }
}
