using DG.Tweening;
using UnityEngine;

public class Lift : ActivatedObject
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Transform _2PointTransform;
    [SerializeField] private float _moveDuration = 5f;

    protected override void DoOnActive()
    {
        if (IsActive)
        {
            _transform.DOMove(_2PointTransform.position, _moveDuration);
        }
    }
}
