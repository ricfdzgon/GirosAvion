using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneTurnRotation : MonoBehaviour
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
        float turnZ = 0;


        //Leemos los inputs
        if (Input.GetKey(KeyCode.A))
        {
            turnY = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            turnY = 1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            turnX = -1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            turnX = 1;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            turnZ = 1;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            turnZ = -1;
        }

        //Aplicamos la rotación
        Vector3 rotationEulerAngles = Vector3.zero;
        rotationEulerAngles.y = turnY * rotationSpeed * Time.deltaTime;
        rotationEulerAngles.x = turnX * rotationSpeed * Time.deltaTime;
        rotationEulerAngles.z = turnZ * rotationSpeed * Time.deltaTime;

        transform.Rotate(rotationEulerAngles, Space.World);
        Dashboard.instance.ShowEulerAngles(transform.eulerAngles);

        //Reseteamos el avión a su posición inicial
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.eulerAngles = initialRotation;
        }
    }
}

