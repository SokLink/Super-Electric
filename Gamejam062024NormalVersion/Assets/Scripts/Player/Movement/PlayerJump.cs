using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRb;
    [SerializeField, Range(0, 25f)] private float _jumpForce;
    [SerializeField, Range(0, 1f)] private float _cayoteTime;
    [Space]
    [SerializeField] private Transform _checkGroundPointTransform;
    [SerializeField] private Vector2 _checkGroundBoxSize;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private bool _debug;

    private float _currentCayoteTime = 0;
    private bool _isGrounded = true;

    private void Start()
    {
        StartCoroutine(JumpTimer());
    }

    private void FixedUpdate()
    {
        Vector2 _checkGroundPointPosition = _checkGroundPointTransform.position;

        if (Physics2D.BoxCast(_checkGroundPointPosition, _checkGroundBoxSize, 0, Vector2.zero, 0, _groundLayer))
        {
            _isGrounded = true;
            _currentCayoteTime = 0;
        }
        else if (_currentCayoteTime >= _cayoteTime)
        {
            _isGrounded = false;
            _currentCayoteTime = _cayoteTime;
        }
    }

    private void Jump()
    {
        if (_isGrounded && PlayerMove.CanMove)
        {
            _playerRb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private IEnumerator JumpTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            _currentCayoteTime += Time.deltaTime;
        }
    }

    private void OnEnable()
    {
        GameInputHandler.OnJumpPressed += Jump;
    }
    private void OnDisable()
    {
        GameInputHandler.OnJumpPressed -= Jump;
    }

    private void OnDrawGizmos()
    {
        if (_debug)
        {
            if (_isGrounded) Gizmos.color = Color.green;
            else Gizmos.color = Color.red;

            Gizmos.DrawWireCube(_checkGroundPointTransform.position, _checkGroundBoxSize);
        }
    }
}
