using UnityEngine;

public class WireConnection : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;

    [SerializeField] private WireHead _startWireHead;
    [SerializeField] private WireHead _endWireHead;

    public Color WireColor = Color.red;
    public WireHead StartWireHead
    {
        get { return _startWireHead; }
        set { _startWireHead = value; }
    }
    public WireHead EndWireHead
    {
        get { return _endWireHead; }
        set { _endWireHead = value; }
    }

    private void OnValidate()
    {
        if (_lineRenderer == null && TryGetComponent(out LineRenderer lineRenderer)) _lineRenderer = lineRenderer;
    }

    private void FixedUpdate()
    {
        _lineRenderer.startColor = WireColor;
        _lineRenderer.endColor = WireColor;

        _lineRenderer.positionCount = 2; //указываем кол-во точек

        Vector2 firstPoint = StartWireHead.WireHeadTransform.position;
        _lineRenderer.SetPosition(0, firstPoint);

        Vector2 secondPoint = EndWireHead.WireHeadTransform.position;
        _lineRenderer.SetPosition(1, secondPoint);

        Debug.DrawLine(firstPoint, secondPoint, WireColor);
    }
}
