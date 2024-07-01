using DG.Tweening;
using UnityEngine;

public class Door : ActivatedObject
{
    [SerializeField] private Vector2 _offset;
    [SerializeField] private Transform _transform;

    private void OnValidate()
    {
        if (_transform == null) _transform = transform;     
    }

    protected override void DoOnActive()
    {
        if (IsActive)
        {
            Vector2 newDoorPosition = (Vector2)_transform.position + _offset;
            _transform.DOMove(newDoorPosition, 2f);
        }
    }
}
