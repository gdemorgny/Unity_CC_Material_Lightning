using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleCamRaycast : MonoBehaviour
{
    [SerializeField] private Image _reticule;
    [SerializeField] private float _usableRange = 2f;
    private IUsableObject _usableObject;
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit, _usableRange))
        {
            if(hit.collider.GetComponent<IUsableObject>() != null)
            {
                _reticule.color = Color.green;
                _usableObject = hit.collider.GetComponent<IUsableObject>();
            } else
            {
                _reticule.color = Color.white;
                _usableObject = null;
            }
        } else
        {
            _reticule.color = Color.white;
            _usableObject = null;
        }
        if (Input.GetKeyDown(KeyCode.U) && _usableObject != null)
        {
            _usableObject.UseObject();

        }


    }
}
