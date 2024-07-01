using UnityEngine;
using UnityEngine.EventSystems;

public class DragableElement : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField] private Transform _elementTransform;

    private Vector2 _offset;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _offset = (Vector2)_elementTransform.position - (Vector2)GameComponentsBus.MainCamera.ScreenToWorldPoint(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _elementTransform.position = (Vector2)GameComponentsBus.MainCamera.ScreenToWorldPoint(eventData.position) + _offset;
    }
}
