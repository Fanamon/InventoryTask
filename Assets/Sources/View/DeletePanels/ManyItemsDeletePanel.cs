using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ManyItemsDeletePanel : MonoBehaviour
{
    private const string PanelMessage = "Do you want to delete ";

    [SerializeField] private Button _acceptButton;
    [SerializeField] private Button _cancelButton;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _sliderValueText;

    private int _itemsCountToDelete;

    public event UnityAction<int> Accepted;

    private void OnEnable()
    {
        _itemsCountToDelete = (int)_slider.value;

        _acceptButton.onClick.AddListener(OnAcceptButtonClicked);
        _cancelButton.onClick.AddListener(OnCancelButtonClicked);
    }

    private void OnDisable()
    {
        _acceptButton.onClick.RemoveListener(OnAcceptButtonClicked);
        _cancelButton.onClick.RemoveListener(OnCancelButtonClicked);
    }

    public void Initialize(string itemTitle, int itemCount)
    {
        gameObject.SetActive(true);
        _text.text = $"{PanelMessage}{itemTitle}?";
        _slider.maxValue = itemCount;
    }

    public void OnSliderValueChanged()
    {
        _itemsCountToDelete = (int)_slider.value;
        _sliderValueText.text = _itemsCountToDelete.ToString();
    }

    private void OnAcceptButtonClicked()
    {
        OnCancelButtonClicked();
        Accepted?.Invoke(_itemsCountToDelete);
    }

    private void OnCancelButtonClicked()
    {
        gameObject.SetActive(false);
    }
}
