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
        //Establece la posición de la cámara
        this.transform.position = _target.TransformPoint(CamOffset);

        //El LookAt método actualiza la rotación de la cápsula en cada fotograma,
        this.transform.LookAt(_target);
    }
}
