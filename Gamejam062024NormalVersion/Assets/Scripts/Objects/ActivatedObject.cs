using UnityEngine;

public abstract class ActivatedObject : MonoBehaviour
{
    private bool _isActivated = false;
    public bool IsActive
    {
        get { return _isActivated; }
        set
        {
            _isActivated = value;
            DoOnActive();
        }
    }

    protected abstract void DoOnActive();
}
