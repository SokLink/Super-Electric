using UnityEngine;

public class ClemmaData : MonoBehaviour
{
    public enum ClemmaType
    {
        L = 0,
        N = 1
    }

    public ClemmaType Type;

    [SerializeField] private WireConnection _connection = null;

    public WireConnection Connection
    {
        get {  return _connection; }
        set { _connection = value; }
    }
}
