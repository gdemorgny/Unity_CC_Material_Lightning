using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelChange : MonoBehaviour,IUsableObject
{
    [SerializeField] private GameObject[] _prefabs;
    private GameObject _actualObject;
    private int _actualPrefab = -1;
    private void Start()
    {
        ChangeObject();
    }

    public void UseObject() { ChangeObject(); }

    private void ChangeObject()
    {
        if(_actualObject != null)
        { 
            Destroy(_actualObject); 
        }
        _actualPrefab++;
        if (_actualPrefab >= _prefabs.Length)
        {
            _actualPrefab = 0;
        }

        _actualObject = Instantiate(_prefabs[_actualPrefab],transform.position,transform.rotation);
    }

}
