using UnityEngine;

public class WireHead : MonoBehaviour
{
    public Transform WireHeadTransform;
    public CanvasGroup WireHeadCanvasGroup;

    [SerializeField] private Transform _defaultParent;

    public Transform DefaultParent
    {
        get { return _defaultParent; }
        set { _defaultParent = value; }
    }

    private void OnValidate()
    {
        if (WireHeadTransform == null) WireHeadTransform = transform;
        if (WireHeadCanvasGroup == null && TryGetComponent(out CanvasGroup canvasGroup)) WireHeadCanvasGroup = canvasGroup;
    }
}
