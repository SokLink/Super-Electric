using UnityEngine;

public class GameComponentsBus : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private WireHead _wirePref;
    [SerializeField] private WireConnection _wireConnectionPref;

    private void OnValidate()
    {
        if (MainCamera == null) MainCamera = _mainCamera;
        if (WirePref == null) WirePref = _wirePref;
        if (WireConnectionPref == null) WireConnectionPref = _wireConnectionPref;
    }

    public static Camera MainCamera;
    public static WireHead WirePref;
    public static WireConnection WireConnectionPref;
}
