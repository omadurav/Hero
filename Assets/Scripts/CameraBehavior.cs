using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Vector3 CamOffset = new Vector3 (0f, 1.2f, -2.6f);

    private Transform _target;

    private void Start()
    {
        _target = GameObject.Find("Player").transform;
    }

    private void LateUpdate()
    {
        //Establece la posici�n de la c�mara
        this.transform.position = _target.TransformPoint(CamOffset);

        //El LookAt m�todo actualiza la rotaci�n de la c�psula en cada fotograma,
        this.transform.LookAt(_target);
    }
}
