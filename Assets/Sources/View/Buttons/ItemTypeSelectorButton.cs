using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemTypeSelectorButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private ItemType _itemType;

    public event UnityAction<ItemType> Clicked;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        Clicked?.Invoke(_itemType);
    }
}