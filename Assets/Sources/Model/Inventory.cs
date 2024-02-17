using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<ItemPack> _startingInventory;

    [Header("Default Filters")]
    [SerializeField] private ItemType _defaultItemTypeFilter;
    [SerializeField] private Effect _defaultEffectFilter;

    private Dictionary<AssetItem, int> _cells = 
        new Dictionary<AssetItem, int>();

    private ItemType _currentItemTypeFilter;
    private Effect _currentEffectFilter;

    public event UnityAction<IEnumerable<KeyValuePair<AssetItem, int>>> InventoryChanged;

    private void OnEnable()
    {
        _currentItemTypeFilter = _defaultItemTypeFilter;
        _currentEffectFilter = _defaultEffectFilter;

        InventoryChanged?.Invoke(GetSortedItemsByType(_currentItemTypeFilter));
    }

    public void Start()
    {
        CreateStartingInventory(_startingInventory);
    }

    public IEnumerable<KeyValuePair<AssetItem, int>> GetSortedItemsByType(ItemType itemType)
    {
        var sortedCells = _cells.Where(cell => cell.Key.Type == itemType);
        _currentItemTypeFilter = itemType;

        if (_currentEffectFilter != null)
        {
            sortedCells = GetSortedItemByEffect(_currentEffectFilter);
        }

        return sortedCells;
    }

    public IEnumerable<KeyValuePair<AssetItem, int>> GetSortedItemByEffect(Effect effect)
    {
        IEnumerable<KeyValuePair<AssetItem, int>> sortedCells;
        _currentEffectFilter = effect;

        if (effect != null)
        {
            sortedCells = _cells.Where(cell => cell.Key.Type == _currentItemTypeFilter && 
            cell.Key.ItemEffect.Effect == effect);
        }
        else
        {
            sortedCells = GetSortedItemsByType(_currentItemTypeFilter);
        }

        return sortedCells;
    }

    public void AddItem(ItemPack itemPack)
    {
        if (TryFindItemInInventory(itemPack.AssetItem))
        {
            _cells[itemPack.AssetItem] += itemPack.Count;
        }
        else
        {
            _cells.Add(itemPack.AssetItem, itemPack.Count);
        }
    }

    public int GetItemCount(AssetItem item)
    {
        return _cells[item];
    }

    public void RemoveItem(AssetItem item)
    {
        _cells.Remove(item);

        InventoryChanged?.Invoke(GetSortedItemsByType(_currentItemTypeFilter));
    }

    public void RemoveItem(AssetItem item, int count)
    {
        _cells[item] -= count;

        if (_cells[item] == 0)
        {
            _cells.Remove(item);
        }

        InventoryChanged?.Invoke(GetSortedItemsByType(_currentItemTypeFilter));
    }

    private bool TryFindItemInInventory(AssetItem itemToFind)
    {
        AssetItem assetItem = _cells.Keys.FirstOrDefault(item => item == itemToFind);

        return assetItem != null;
    }

    private void CreateStartingInventory(List<ItemPack> itemPack)
    {
        Dictionary<AssetItem, int> startingInventory = new Dictionary<AssetItem, int>();

        foreach (var item in itemPack)
        {
            startingInventory.Add(item.AssetItem, item.Count);
            _cells.Add(item.AssetItem, item.Count);
        }

        OnEnable();
    }
}