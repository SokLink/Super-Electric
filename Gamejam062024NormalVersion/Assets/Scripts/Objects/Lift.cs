using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Lift : ActivatedObject
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Transform _2PointTransform;
    [SerializeField] private float _moveDuration = 5f;
    [SerializeField] private bool _isReturning = false;
    [SerializeField] private float _timeBetweenReturning = 2.5f;
    [SerializeField] private string _playerTag;

    private Vector2 _defaultPos;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _playerTag)
        {
            collision.transform.parent = _transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _playerTag)
        {
            collision.transform.parent = null;
        }
    }

    protected override void DoOnActive()
    {
        if (IsActive)
        {
            if (_isReturning)
            {
                StartCoroutine(TudaSudaLift());
            }
            else
            {
                _transform.DOMove(_2PointTransform.position, _moveDuration);
            }
        }
    }

    private IEnumerator TudaSudaLift()
    {
        _defaultPos = _transform.position;

        while (true)
        {
            _transform.DOMove(_2PointTransform.position, _moveDuration);

            yield return new WaitForSeconds(_moveDuration + _timeBetweenReturning);

            _transform.DOMove(_defaultPos, _moveDuration);

            yield return new WaitForSeconds(_moveDuration + _timeBetweenReturning);
        }
    }
}
