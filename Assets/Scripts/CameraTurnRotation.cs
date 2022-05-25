using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTurnRotation : MonoBehaviour
{
    Vector3 initialRotation;
    private float rotationSpeed = 90f;
    void Start()
    {
        initialRotation = transform.eulerAngles;
    }

    void Update()
    {
        if (MasterController.instance.cSharpRotation != CSharpRotation.Rotation)
        {
            return;
        }

        float turnX = 0;
        float turnY = 0;

        if (Input.GetKey(KeyCode.J))
        {
            turnY = -1;
        }
        else if (Input.GetKey(KeyCode.L))
        {
            turnY = 1;
        }

        if (Input.GetKey(KeyCode.I))
        {
            turnX = 1;
        }
        else if (Input.GetKey(KeyCode.K))
        {
            turnX = -1;
        }

        Vector3 rotation = Vector3.zero;
        rotation.x = turnX * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation, Space.Self);

        rotation = Vector3.zero;
        rotation.y = turnY * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation, Space.World);

        //Reseteamos el avión a su posición inicial
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.eulerAngles = initialRotation;
        }
    }
}
