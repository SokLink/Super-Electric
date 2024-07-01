using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    [SerializeField] private string _playerTag;

    protected bool CanInteract = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == _playerTag)
        {
            CanInteract = true;
        }
        else CanInteract = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CanInteract = false;
    }

    private void CheckCanInteract()
    {
        if (CanInteract)
        {
            DoOnInteract();
        }
    }

    protected abstract void DoOnInteract();

    private void OnEnable()
    {
        GameInputHandler.OnInteractPressed += CheckCanInteract;
    }
    private void OnDisable()
    {
        GameInputHandler.OnInteractPressed -= CheckCanInteract;
    }
}
