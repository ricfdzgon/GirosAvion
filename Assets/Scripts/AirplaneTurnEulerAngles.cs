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
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            turnY = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            turnY = 1;
        }

        //Aplicamos los giros
        Vector3 newEulerAngles = transform.eulerAngles;
        newEulerAngles.y += turnY * rotationSpeed * Time.deltaTime;
        transform.eulerAngles = newEulerAngles;

        //Reseteamos el avión a su posición inicial
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.eulerAngles = initialRotation;
        }
    }

}