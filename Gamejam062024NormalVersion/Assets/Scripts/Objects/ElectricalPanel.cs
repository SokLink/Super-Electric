using UnityEngine;

public class ElectricalPanel : InteractableObject
{
    [SerializeField] private GameObject _electricPanel;

    protected override void DoOnInteract()
    {
        _electricPanel.SetActive(!_electricPanel.activeSelf);
        PlayerMove.CanMove = !PlayerMove.CanMove;
    }
}
