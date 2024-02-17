using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DeleteItemButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    private AssetItem _item;

    public event UnityAction<AssetItem> Clicked;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);

        Clear();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    public void InitializeItem(AssetItem item)
    {
        _item = item;
    }

    private void Clear()
    {
        _item = null;
    }

    private void OnButtonClicked()
    {
        Clicked?.Invoke(_item);
    }
}
