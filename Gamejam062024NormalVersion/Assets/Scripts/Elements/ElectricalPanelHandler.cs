using System.Collections.Generic;
using UnityEngine;

public class ElectricalPanelHandler : ActivatedObject
{
    [SerializeField] private List<Element> _elements = new List<Element>();
    [SerializeField] private ActivatedObject _condition;

    protected override void DoOnActive() { }

    private void FixedUpdate()
    {
        if (_condition == null || _condition.IsActive)
        {
            IsActive = true;

            foreach (Element element in _elements)
            {
                if (!element.ElementIsActive)
                {
                    IsActive = false;
                }
            }
        }
        else
        {
            IsActive = false;
        }
    }
}
