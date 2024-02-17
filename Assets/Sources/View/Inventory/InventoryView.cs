using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    private const int MinEvenNumber = 2;

    [SerializeField] private InventoryCellViewPool _pool;

    public void Render(IEnumerable<KeyValuePair<AssetItem, int>> cells)
    {
        _pool.DisableAllCells();

        foreach (var cell in cells)
        {
            var cellView = _pool.GetDisabledInventoryCellView();
            cellView.gameObject.SetActive(true);
            cellView.Render(cell.Key, cell.Value);
        }

        if (CheckNumberForEvenness(cells.Count()) == false)
        {
            var emptyCellView = _pool.GetDisabledInventoryCellView();
            emptyCellView.gameObject.SetActive(true);
        }
    }

    private bool CheckNumberForEvenness(int number)
    {
        return number % MinEvenNumber == 0;
    }
}
