using UnityEngine;
using UnityEngine.UI;

public class CancelInventoryButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _inventoryButton;
    [SerializeField] private GameObject _inventory;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        Time.timeScale = 1f;
        _inventory.SetActive(false);
        _inventoryButton.SetActive(true);
        gameObject.SetActive(false);
    }
}
