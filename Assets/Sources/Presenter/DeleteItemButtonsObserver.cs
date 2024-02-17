using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeleteItemButtonsObserver : MonoBehaviour
{
    private const int MinItemCountInInventory = 1;

    [SerializeField] private Transform _cellContainer;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private InventoryView _inventoryView;

    [Header("Delete panels")]
    [SerializeField] private OneItemDeletePanel _oneItemDeletePanel;
    [SerializeField] private ManyItemsDeletePanel _manyItemsDeletePanel;

    private bool _isItemsRemoved = false;

    private AssetItem _itemToRemove;
    private List<DeleteItemButton> _buttons = new List<DeleteItemButton>();

    private void OnEnable()
    {
        _oneItemDeletePanel.Accepted += OnOneItemButtonAccepted;
        _manyItemsDeletePanel.Accepted += OnManyItemsButtonAccepted;

        foreach (var button in _buttons)
        {
            button.Clicked += OnClicked;
        }
    }

    private void OnDisable()
    {
        _oneItemDeletePanel.Accepted -= OnOneItemButtonAccepted;
        _manyItemsDeletePanel.Accepted -= OnManyItemsButtonAccepted;

        _oneItemDeletePanel.gameObject.SetActive(false);
        _manyItemsDeletePanel.gameObject.SetActive(false);

        foreach (var button in _buttons)
        {
            button.Clicked -= OnClicked;
        }
    }

    private void Start()
    {
        _buttons = _cellContainer.GetComponentsInChildren<DeleteItemButton>(true).ToList();

        OnEnable();
    }

    private void OnClicked(AssetItem item)
    {
        int itemCountInInventory = _inventory.GetItemCount(item);

        if (itemCountInInventory == MinItemCountInInventory)
        {
            _oneItemDeletePanel.Initialize(item.Title);
        }
        else
        {
            _isItemsRemoved = false;
            _manyItemsDeletePanel.Initialize(item.Title, itemCountInInventory);
        }

        _itemToRemove = item;
    }

    private void OnOneItemButtonAccepted()
    {
        _inventory.RemoveItem(_itemToRemove);
    }

    private void OnManyItemsButtonAccepted(int count)
    {
        if (_isItemsRemoved == false)
        {
            _inventory.RemoveItem(_itemToRemove, count);
            _isItemsRemoved = true;
        }
    }
}
