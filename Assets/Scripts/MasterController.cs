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

    // Update is called once per frame
    void Update()
    {

    }
}

public enum CSharpRotation
{
    Rotation,
    EulerAngles
}