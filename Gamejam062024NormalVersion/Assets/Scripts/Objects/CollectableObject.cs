using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    [SerializeField] private string _playerTag;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == _playerTag)
        {
            Inventory.ProvodaCount += 1;
            Destroy(gameObject);
        }
    }
}
