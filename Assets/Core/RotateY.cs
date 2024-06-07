using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateY : MonoBehaviour
{
    public float rotationSpeed = 30f; // Rotationsgeschwindigkeit in Grad pro Sekunde

    void Update()
    {
        // Rotieren des GameObjects um die Y-Achse
        float rotationAmount = rotationSpeed * Time.deltaTime;
        transform.Rotate(0f, rotationAmount, 0f);
    }
}
