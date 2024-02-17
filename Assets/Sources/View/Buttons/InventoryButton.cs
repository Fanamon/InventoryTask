using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _cancelButton;
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
        Time.timeScale = 0f;
        _inventory.SetActive(true);
        _cancelButton.SetActive(true);
        gameObject.SetActive(false);
    }
}