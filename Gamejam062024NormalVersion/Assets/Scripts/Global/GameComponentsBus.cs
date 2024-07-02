using UnityEngine;

public class GameComponentsBus : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private GameObject _wirePref;
    [SerializeField] private GameObject _wireConnectionPref;

    private void Awake()
    {
        MainCamera = _mainCamera;
        WirePref = _wirePref;
        WireConnectionPref = _wireConnectionPref;
    }

    public static Camera MainCamera;
    public static GameObject WirePref;
    public static GameObject WireConnectionPref;
}
