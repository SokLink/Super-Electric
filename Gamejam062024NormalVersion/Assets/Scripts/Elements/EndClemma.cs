using UnityEngine;
using UnityEngine.EventSystems;

public class EndClemma : MonoBehaviour, IDropHandler
{
    [SerializeField] private Transform _clemmaTransform;
    [SerializeField] private ClemmaData _clemmaData;

    private void OnValidate()
    {
        if (_clemmaTransform == null) _clemmaTransform = transform;
        if (_clemmaData == null && TryGetComponent(out ClemmaData clemmaData)) _clemmaData = clemmaData;
    }



    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent(out StartClemma startClemma) && _clemmaData.Connection == null)
        {
            if (startClemma.StartClemmaData.Connection != null)
            {
                if (startClemma.StartClemmaData.Type == _clemmaData.Type)
                {
                    startClemma.StartClemmaData.Connection.EndWireHead.DefaultParent = _clemmaTransform;
                    startClemma.StartClemmaData.Connection.EndWireHead.WireHeadTransform.position = _clemmaTransform.position;
                    _clemmaData.Connection = startClemma.StartClemmaData.Connection;
                }
                else
                {
                    print("›À≈ “–ŒÿŒ !");
                }
            }
        }
    }
}
