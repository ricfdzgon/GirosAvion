using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviour
{
    public static MasterController instance;
    public CSharpRotation cSharpRotation { get; private set; }

    public Space rotationReference { get; private set; }
    void Awake()
    {
        instance = this;
        cSharpRotation = CSharpRotation.Rotation;
        rotationReference = Space.World;
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

    public void ToggleRotationReference()
    {
        if (rotationReference == Space.Self)
        {
            rotationReference = Space.World;
        }
        else
        {
            rotationReference = Space.Self;
        }
    }
}

public enum CSharpRotation
{
    Rotation,
    EulerAngles
}