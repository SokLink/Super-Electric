using UnityEngine;

public class ReturnFloor : MonoBehaviour
{
    [SerializeField] private Transform _returnPosPointTransform;
    [SerializeField] private string _playerTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == _playerTag)
        {
            collision.transform.position = _returnPosPointTransform.position;
        }
    }
}
