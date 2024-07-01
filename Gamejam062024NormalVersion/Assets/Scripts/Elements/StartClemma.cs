using UnityEngine;
using UnityEngine.EventSystems;

public class StartClemma : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Transform _clemmaTransform;
    [SerializeField] private ClemmaData _clemmaData;

    public ClemmaData StartClemmaData => _clemmaData;



    private void OnValidate()
    {
        if (_clemmaTransform == null) _clemmaTransform = transform;
        if (_clemmaData == null && TryGetComponent(out ClemmaData clemmaData)) _clemmaData = clemmaData;
    }



    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_clemmaData.Connection != null)
        {
            Destroy(_clemmaData.Connection.StartWireHead.gameObject);
            Destroy(_clemmaData.Connection.EndWireHead.gameObject);
            Destroy(_clemmaData.Connection.gameObject);
        }
        else if (Inventory.ProvodaCount <= 0)
        {
            return;
        }
        else
        {
            Inventory.ProvodaCount -= 1;
        }

        WireHead startWireHead = Instantiate(GameComponentsBus.WirePref, _clemmaTransform.position, Quaternion.identity);
        startWireHead.DefaultParent = _clemmaTransform;
        startWireHead.WireHeadTransform.SetParent(_clemmaTransform);

        WireHead endWireHead = Instantiate(GameComponentsBus.WirePref, _clemmaTransform.position, Quaternion.identity);
        endWireHead.WireHeadTransform.SetParent(null);
        endWireHead.WireHeadCanvasGroup.blocksRaycasts = false;

        _clemmaData.Connection = Instantiate(GameComponentsBus.WireConnectionPref, Vector2.zero, Quaternion.identity);
        _clemmaData.Connection.gameObject.transform.parent = _clemmaTransform;
        _clemmaData.Connection.StartWireHead = startWireHead;
        _clemmaData.Connection.EndWireHead = endWireHead;

        if (_clemmaData.Type == 0) _clemmaData.Connection.WireColor = Color.red;
        else if ((int)_clemmaData.Type == 1) _clemmaData.Connection.WireColor = Color.blue;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_clemmaData.Connection != null) _clemmaData.Connection.EndWireHead.WireHeadTransform.position = (Vector2)GameComponentsBus.MainCamera.ScreenToWorldPoint(eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_clemmaData.Connection != null)
        {
            if (_clemmaData.Connection.EndWireHead.DefaultParent != null)
            {
                _clemmaData.Connection.EndWireHead.WireHeadTransform.SetParent(_clemmaData.Connection.EndWireHead.DefaultParent);
            }
            else
            {
                Inventory.ProvodaCount += 1;

                Destroy(_clemmaData.Connection.StartWireHead.gameObject);
                Destroy(_clemmaData.Connection.EndWireHead.gameObject);
                Destroy(_clemmaData.Connection.gameObject);
            }
        }
    }



    public void OnDrawGizmos()
    {
        if (_clemmaData.Connection != null && _clemmaData.Connection.StartWireHead != null && _clemmaData.Connection.EndWireHead != null)
        {
            if (_clemmaData.Type == 0) Gizmos.color = Color.red;
            else if ((int)_clemmaData.Type == 1) Gizmos.color = Color.blue;

            Gizmos.DrawLine(_clemmaData.Connection.StartWireHead.WireHeadTransform.position,
                _clemmaData.Connection.EndWireHead.WireHeadTransform.position);
        }
    }
}
