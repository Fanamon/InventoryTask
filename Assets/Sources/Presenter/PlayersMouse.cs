using Unity.VisualScripting;
using UnityEngine;

public class PlayersMouse : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;

    private void Update()
    {
        if (Input.GetMouseButtonDown((int)MouseButton.Left))
        {
            if (LookForGameObject(out RaycastHit2D hit) && hit.transform.TryGetComponent(out ItemPack itemPack))
            {
                _inventory.AddItem(itemPack);
                Destroy(itemPack.gameObject);
            }
        }
    }

    private bool LookForGameObject(out RaycastHit2D hit)
    {
        hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

        return hit.collider != null;
    }
}
