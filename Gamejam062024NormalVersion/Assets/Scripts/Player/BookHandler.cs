using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookHandler : MonoBehaviour
{
    [SerializeField] private GameObject _book;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            _book.SetActive(!_book.activeSelf);
        }
    }
}
