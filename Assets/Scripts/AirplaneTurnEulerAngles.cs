using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneTurnEulerAngles : MonoBehaviour
{
    Vector3 initialRotation;
    private float rotationSpeed = 90f;
    void Start()
    {
        initialRotation = transform.eulerAngles;
    }
    void Update()
    {
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

        //Aplicamos los giros
        Vector3 newEulerAngles = transform.eulerAngles;
        newEulerAngles.y += turnY * rotationSpeed * Time.deltaTime;
        newEulerAngles.x += turnX * rotationSpeed * Time.deltaTime;
        newEulerAngles.z += turnZ * rotationSpeed * Time.deltaTime;

        transform.eulerAngles = newEulerAngles;

        Dashboard.instance.ShowEulerAngles(newEulerAngles);

        //Reseteamos el avión a su posición inicial
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.eulerAngles = initialRotation;
        }
    }

}