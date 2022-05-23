using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTurnEulerAngles : MonoBehaviour
{
    Vector3 initialRotation;
    private float rotationSpeed = 90f;
    void Start()
    {
        initialRotation = transform.eulerAngles;
    }

    void Update()
    {
        if (MasterController.instance.cSharpRotation != CSharpRotation.EulerAngles)
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

        //Reseteamos el avión a su posición inicial
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.eulerAngles = initialRotation;
        }

        //Aplicamos los giros
        Vector3 newEulerAngles = transform.eulerAngles;
        if (MasterController.instance.rotationReference == Space.Self)
        {
            newEulerAngles = transform.localEulerAngles;
        }

        newEulerAngles.y += turnY * rotationSpeed * Time.deltaTime;
        newEulerAngles.x += turnX * rotationSpeed * Time.deltaTime;

        if (MasterController.instance.rotationReference == Space.World)
        {

            transform.eulerAngles = newEulerAngles;
        }
        else
        {
            transform.localEulerAngles = newEulerAngles;
        }

    }
}
