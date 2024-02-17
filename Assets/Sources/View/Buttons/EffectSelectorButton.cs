using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EffectSelectorButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Effect _effect;

    public event UnityAction<Effect> Clicked;

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
        Clicked?.Invoke(_effect);
    }
}
