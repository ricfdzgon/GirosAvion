using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviour
{
    public static MasterController instance;
    public CSharpRotation cSharpRotation { get; private set; }

    void Awake()
    {
        instance = this;
        cSharpRotation = CSharpRotation.Rotation;
    }

    void Update()
    {

    }

    public void ToggleCSharpRotation()
    {
        if (cSharpRotation == CSharpRotation.EulerAngles)
        {
            cSharpRotation = CSharpRotation.Rotation;
        }
        else
        {
            cSharpRotation = CSharpRotation.EulerAngles;
        }
    }
}

public enum CSharpRotation
{
    Rotation,
    EulerAngles
}