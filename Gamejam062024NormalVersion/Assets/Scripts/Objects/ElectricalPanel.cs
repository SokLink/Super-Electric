using Cinemachine;
using UnityEngine;

public class ElectricalPanel : InteractableObject
{
    [SerializeField] private GameObject _electricPanel;
    [SerializeField] private bool _isReactor = false;
    [SerializeField] private Transform _newCameraPosTransform;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private CinemachineVirtualCamera _cinemachinCamera;

    private bool _reactorActivated = false;

    protected override void DoOnInteract()
    {
        if (_isReactor)
        {
            if (_reactorActivated)
            {
                _cinemachinCamera.Follow = _playerTransform;
                _reactorActivated = false;
            }
            else
            {
                _cinemachinCamera.Follow = _newCameraPosTransform;
                _reactorActivated = true;
            }
        }
        else
        {
            _electricPanel.SetActive(!_electricPanel.activeSelf);
        }

        PlayerMove.CanMove = !PlayerMove.CanMove;
    }
}
