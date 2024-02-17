using UnityEngine;

public class ItemPack : MonoBehaviour
{
    [SerializeField] private AssetItem _assetItem;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private int _count;

    public AssetItem AssetItem => _assetItem;
    public int Count => _count;

    public void Initialize(int count)
    {
        _count = count;
        _spriteRenderer.sprite = _assetItem.Icon;
    }

    private void OnValidate()
    {
        if (_count < 0)
        {
            _count = Mathf.Abs(_count);
        }
    }
}
