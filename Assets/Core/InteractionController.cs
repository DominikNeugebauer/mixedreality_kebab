using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class InteractionController : MonoBehaviour
{
    public InputActionProperty rightControllerPrimaryButton; // Verweis auf die Input Action

    private void OnEnable()
    {
        rightControllerPrimaryButton.action.Enable();
    }

    private void OnDisable()
    {
        rightControllerPrimaryButton.action.Disable();
    }

    void Update()
    {
        Debug.LogError("A button on the right controller was pressed");

        if (rightControllerPrimaryButton.action.WasPressedThisFrame())
        {
            Debug.LogError("A button on the right controller was pressed");
        }
    }
}
