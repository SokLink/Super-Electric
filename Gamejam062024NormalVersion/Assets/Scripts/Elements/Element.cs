using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    [SerializeField] private List<ClemmaData> _clemmsData = new List<ClemmaData>();
    [SerializeField] private bool _isSynyayaHren = false;
    [SerializeField] private List<ClemmaData> _clemmsDataVyhod = new List<ClemmaData>();

    public bool ElementIsActive { get; private set; }

    private void FixedUpdate()
    {
        if (_isSynyayaHren)
        {
            bool vhodActive = false;
            bool vyhodActive = false;

            foreach (ClemmaData clemmaData in _clemmsData)
            {
                if (clemmaData.Connection != null) vhodActive = true;
            }

            foreach (ClemmaData clemmaData in _clemmsDataVyhod)
            {
                if (clemmaData.Connection != null) vyhodActive = true;
            }

            if (vhodActive && vyhodActive) ElementIsActive = true;
            else ElementIsActive = false;
        }
        else
        {
            ElementIsActive = true;

            foreach (ClemmaData clemmaData in _clemmsData)
            {
                if (clemmaData.Connection == null) ElementIsActive = false;
            }
        }
    }
}
