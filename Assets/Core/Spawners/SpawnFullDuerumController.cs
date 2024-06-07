using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFullDuerumController : MonoBehaviour
{
    public int onionCounter = 0;
    public int tomatoCounter = 0;
    public int cucumberCounter = 0;
    public int lettuceCounter = 0;
    public int meatCounter = 0;

    public bool isSauce = false;

    public GameObject fullDuerum;

    private void OnTriggerEnter(Collider other)
    {
        switch(other.name)
        {
            case "Tomato(Clone)":
                tomatoCounter++;
                break;
            case "Onion(Clone)":
                onionCounter++;
                break;
            case "Cucumber(Clone)":
                cucumberCounter++;
                break;
            case "Lettuce(Clone)":
                lettuceCounter++;
                break;
            case "Meat(Clone)":
                meatCounter++;
                break;
        }

        if(
            tomatoCounter >= 1 &&
            onionCounter >= 1 &&
            cucumberCounter >= 1 &&
            lettuceCounter >= 1 &&
            meatCounter >= 2 &&
            isSauce
        ) {
            Destroy(gameObject);
            DeleteIngredientsInCollider();
            Instantiate(fullDuerum, transform.position, transform.rotation);
        }
    }

    public void DeleteIngredientsInCollider()
    {
        BoxCollider collider = GetComponent<BoxCollider>();
        GameObject[] objects = UnityEngine.Object.FindObjectsOfType<GameObject>();

        foreach (GameObject o in objects)
        {
            if (collider.bounds.Contains(o.transform.position) &&
                (
                    o.name == "Tomato(Clone)" ||
                    o.name == "Lettuce(Clone)" ||
                    o.name == "Onion(Clone)" ||
                    o.name == "Meat(Clone)" ||
                    o.name == "Cucumber(Clone)"
                )
            )
            {
                Debug.LogWarning("Da kommtein Dürüm,!!!!!");
                Destroy(o);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch(other.name)
        {
            case "Tomato(Clone)":
                tomatoCounter--;
                break;
            case "Onion(Clone)":
                onionCounter--;
                break;
            case "Cucumber(Clone)":
                cucumberCounter--;
                break;
            case "Lettuce(Clone)":
                lettuceCounter--;
                break;
            case "Meat(Clone)":
                meatCounter--;
                break;
        }
    }
}
