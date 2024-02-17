using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryCellViewPool : MonoBehaviour
{
    [SerializeField] private InventoryCellView _inventoryCellViewTemplate;
    [SerializeField] private Transform _container;
    [SerializeField] private int _count;

    private List<InventoryCellView> _inventoryCellViewPool = new List<InventoryCellView>();

    public void Awake()
    {
        SpawnInventoryCellViews();
    }

    public InventoryCellView GetDisabledInventoryCellView()
    {
        return _inventoryCellViewPool.First(cellView => cellView.gameObject.activeSelf == false);
    }

    public void DisableAllCells()
    {
        foreach (var cellView in _inventoryCellViewPool)
        {
            cellView.gameObject.SetActive(false);
        }
    }

    private void SpawnInventoryCellViews()
    {
        for (int i = 0; i < _count; i++)
        {
            InventoryCellView cellView = Instantiate(_inventoryCellViewTemplate, _container);

            _inventoryCellViewPool.Add(cellView);
            cellView.gameObject.SetActive(false);
        }
    }

    private void OnValidate()
    {
        if (_count < 0)
        {
            _count = Mathf.Abs(_count);
        }
    }
}
