using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dashboard : MonoBehaviour
{
    //El instance es un Singleton
    public static Dashboard instance;
    public TextMeshProUGUI eulerAngleXText;
    public TextMeshProUGUI eulerAngleYText;
    public TextMeshProUGUI eulerAngleZText;
    public TextMeshProUGUI valorCSharpText;
    public TextMeshProUGUI valorRotationText;


    void Start()
    {
        ShowCSharpRotation();
        ShowRotationReference();
    }
    void Awake()
    {
        instance = this;
    }

    void Update()
    {

    }

    //Esta función de arriba es conocida como wrapper
    public void ShowEulerAngles(Vector3 eulerAngles)
    {
        ShowEulerAngles(eulerAngles.x, eulerAngles.y, eulerAngles.z);
    }

    public void ShowCSharpRotation()
    {
        valorCSharpText.text = MasterController.instance.cSharpRotation.ToString();
    }

    public void ShowRotationReference()
    {
        valorRotationText.text = MasterController.instance.rotationReference.ToString();
    }
    public void ShowEulerAngles(float eulerX, float eulerY, float eulerZ)
    {
        eulerAngleXText.text = formatAngle(eulerX);
        eulerAngleYText.text = formatAngle(eulerY);
        eulerAngleZText.text = formatAngle(eulerZ);
    }

    private string formatAngle(float angle)
    {
        return (Mathf.Round(angle * 100) / 100.0f).ToString();
    }

    public void ToggleCSharpButtonOnClick()
    {
        MasterController.instance.ToggleCSharpRotation();
        ShowCSharpRotation();
    }
    public void ToggleRotationButtonOnClick()
    {
        MasterController.instance.ToggleRotationReference();
        ShowRotationReference();
    }
}
