using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCellView : MonoBehaviour
{
    private const string CountText = "X";
    private const string EffectPowerText = "+";

    [SerializeField] private Image _iconField;
    [SerializeField] private TMP_Text _countField;
    [SerializeField] private Image _effectIconField;
    [SerializeField] private TMP_Text _effectPowerField;
    [SerializeField] private DeleteItemButton _deleteItemButton;

    private void OnEnable()
    {
        Clear();
    }

    public void Render(IItem item, int count)
    {
        _iconField.gameObject.SetActive(true);
        _deleteItemButton.gameObject.SetActive(true);
        _iconField.sprite = item.Icon;
        _countField.text = $"{CountText}{count}";
        _deleteItemButton.InitializeItem(item as AssetItem);

        if (item.ItemEffect.Effect != null)
        {
            _effectIconField.gameObject.SetActive(true);
            _effectIconField.sprite = item.ItemEffect.Effect.Icon;
            _effectPowerField.text = $"{EffectPowerText}{item.ItemEffect.Power}";
        }
    }

    private void Clear()
    {
        _iconField.gameObject.SetActive(false);
        _countField.text = null;
        _effectIconField.gameObject.SetActive(false);
        _effectPowerField.text = null;
        _deleteItemButton.gameObject.SetActive(false);
    }
}
