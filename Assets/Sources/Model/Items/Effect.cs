using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Effect", menuName = "Effect/Create new effect", order = 51)]
public class Effect : ScriptableObject
{
    [SerializeField] private EffectType effectType;
    [SerializeField] private Sprite _icon;

    public Sprite Icon => _icon;
}

[Serializable]
public struct ItemEffect : ISerializationCallbackReceiver
{
    [SerializeField] private int _power;

    [SerializeField] private Effect _effect;

    public int Power => _power;
    public Effect Effect => _effect;

    public void OnBeforeSerialize() => OnValidate();

    public void OnAfterDeserialize() { }

    private void OnValidate()
    {
        if (_power < 0)
        {
            _power = Mathf.Abs(_power);
        }
    }
}

public enum EffectType
{
    Heal,
    Sleep,
    Speed,
    Frost,
    Health,
    Poison,
    Fire,
    Damage,
    Holy,
    Slow,
    Lightning
}