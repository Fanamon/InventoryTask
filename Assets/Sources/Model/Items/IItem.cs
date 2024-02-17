using UnityEngine;

public interface IItem
{
    string Title { get; }
    ItemType Type { get; }
    Sprite Icon { get; }
    ItemEffect ItemEffect { get; }
}
