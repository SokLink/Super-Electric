using Unity.VisualScripting;
using UnityEngine;

public class PlayerStairsMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRb;
    [SerializeField, Range(0, 25f)] private float _speed;
    [Space]
    [SerializeField] private Vector2 _ckeckStairBoxSize;
    [SerializeField] private LayerMask _stairLayer;

    private void FixedUpdate()
    {
        if (PlayerMove.CanMove && Physics2D.BoxCast(_playerRb.position, _ckeckStairBoxSize, 0, Vector2.zero, 0, _stairLayer))
        {
            _playerRb.gravityScale = 0;

            float targetSpeed = GameInputHandler.MoveDirection.y * _speed;

            _playerRb.velocity = new Vector2(_playerRb.velocity.x, targetSpeed);
        }
        else
        {
            _playerRb.gravityScale = 1f;
        }
    }
}
