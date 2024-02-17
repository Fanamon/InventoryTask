using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawner : MonoBehaviour
{
    private const int MaxItemCount = 150;

    [SerializeField] private Transform _spawnCircleCenter;
    [SerializeField] private Transform _radiusHandler;

    [SerializeField] private float _spawningTimeInSeconds = 5f;
    [SerializeField] private List<ItemPack> _items = new List<ItemPack>();

    private void Awake()
    {
        StartCoroutine(SpawnItem());
    }

    private IEnumerator SpawnItem()
    {
        int randomItemCount;
        int randomItemIndex;

        System.Random random = new System.Random();
        WaitForSeconds waitingTime = new WaitForSeconds(_spawningTimeInSeconds);

        while (Application.isPlaying)
        {
            randomItemIndex = random.Next(_items.Count);
            randomItemCount = random.Next(MaxItemCount);

            Vector3 randomPosition = GetRandomPointInCircle();

            var newItemPack = Instantiate(_items[randomItemIndex], randomPosition, Quaternion.identity);
            newItemPack.Initialize(randomItemCount);

            yield return waitingTime;
        }
    }

    private Vector2 GetRandomPointInCircle()
    {
        Vector2 centerPoint = _spawnCircleCenter.position;

        return Random.insideUnitCircle * _radiusHandler.localPosition.magnitude + centerPoint;
    }
}
