using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create new item", order = 51)]
public class AssetItem : ScriptableObject, IItem
{
    [SerializeField] private string _title;
    [SerializeField] private ItemType _type;
    [SerializeField] private Sprite _icon;
    [SerializeField] private ItemEffect _itemEffect;

    public string Title => _title;
    public ItemType Type => _type;
    public Sprite Icon => _icon;
    public ItemEffect ItemEffect => _itemEffect;
}

public enum ItemType
{
    Armor,
    Weapon,
    Ammo
}