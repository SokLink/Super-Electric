using UnityEngine;

public class EndGame : ActivatedObject
{
    [SerializeField] private GameObject _endPanel;

    protected override void DoOnActive()
    {
        _endPanel.SetActive(true);
        PlayerMove.CanMove = false;
    }
}
