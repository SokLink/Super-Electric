using UnityEngine;

public class Button : InteractableObject
{
    [SerializeField] private ActivatedObject _condition;
    [SerializeField] private ActivatedObject _activableObject;

    protected override void DoOnInteract()
    {
        if (_condition == null || _condition.IsActive)
        {
            _activableObject.IsActive = true;
        }
    }
}
