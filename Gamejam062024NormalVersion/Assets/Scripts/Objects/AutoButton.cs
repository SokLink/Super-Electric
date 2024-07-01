using UnityEngine;

public class AutoButton : MonoBehaviour
{
    [SerializeField] private ActivatedObject _condition;
    [SerializeField] private ActivatedObject _activableObject;

    private bool _isActivated = false;

    protected void FixedUpdate()
    {
        if ((_condition == null || _condition.IsActive) && !_isActivated)
        {
            _activableObject.IsActive = true;
            _isActivated = true;
        }
    }
}
