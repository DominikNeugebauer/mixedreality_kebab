using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSauceOnDuerumController : MonoBehaviour
{
    public int sauceAmountNeeded = 20;

    public int sauceCounter = 0; 

    public GameObject saucePlaceholder;

    SpawnFullDuerumController duerumSpawner;

    // Start is called before the first frame update
    void Start()
    {
        duerumSpawner = GetComponentInParent<SpawnFullDuerumController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "sauce")
        {
            sauceCounter++;
            Destroy(other);
        }

        if(sauceCounter >= sauceAmountNeeded) {
            saucePlaceholder.SetActive(true);
            duerumSpawner.isSauce = true;
        }
    }
}
