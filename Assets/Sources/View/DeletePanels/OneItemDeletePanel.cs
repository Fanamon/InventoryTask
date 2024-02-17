using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OneItemDeletePanel : MonoBehaviour
{
    private const string PanelMessage = "Do you want to delete ";

    [SerializeField] private Button _acceptButton;
    [SerializeField] private Button _cancelButton;
    [SerializeField] private TMP_Text _text;

    public event UnityAction Accepted;

    private void OnEnable()
    {
        _acceptButton.onClick.AddListener(OnAcceptButtonClicked);
        _cancelButton.onClick.AddListener(OnCancelButtonClicked);
    }

    private void OnDisable()
    {
        _acceptButton.onClick.RemoveListener(OnAcceptButtonClicked);
        _cancelButton.onClick.RemoveListener(OnCancelButtonClicked);
    }

    public void Initialize(string itemTitle)
    {
        gameObject.SetActive(true);
        _text.text = $"{PanelMessage}{itemTitle}?";
    }

    private void OnAcceptButtonClicked()
    {
        Accepted?.Invoke();

        OnCancelButtonClicked();
    }

    private void OnCancelButtonClicked()
    {
        gameObject.SetActive(false);
    }
}
