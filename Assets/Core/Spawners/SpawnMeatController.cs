using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeatController : MonoBehaviour
{
    // Define a cut length threshold
    public float cutLength = 1.0f;

    public GameObject meatPrefab;

    // Store the initial position when the trigger is entered
    private Vector3 enterPosition;

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning(other.tag);
        if (other.tag == "knife")
        {
            enterPosition = other.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "knife")
        {
            Vector3 exitPosition = other.transform.position;
            float distance = Vector3.Distance(enterPosition, exitPosition);

            if (distance >= cutLength)
            {
                for (int i = 0; i < 3; i++)
                {
                    float scaleMultiplier = Random.Range(0.5f, 1.0f);
                    GameObject spawnedMeat = Instantiate(meatPrefab, other.transform.position, other.transform.rotation);
                    spawnedMeat.transform.localScale = meatPrefab.transform.localScale * scaleMultiplier;
                }
            }
        }
    }
}