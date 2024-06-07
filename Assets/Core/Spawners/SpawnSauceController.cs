using UnityEngine;
using System.Collections;
using Oculus.Interaction;

public class SpawnSauceController : MonoBehaviour
{
    public GameObject prefabToSpawn; // Das Prefab, das gespawned werden soll
    public Transform spawnPosition; // Die Position, an der das Prefab gespawned werden soll

    private GrabInteractable grabInteractable;
    private bool isGrabbed = false;
    private bool isSpawning = false;

    void Start()
    {
        // Hol das GrabInteractable Component
        grabInteractable = GetComponent<GrabInteractable>();
        if (grabInteractable == null)
        {
            Debug.LogError("GrabInteractable component not found on this object.");
            return;
        }

        // Abonniere das WhenSelect und WhenUnselect Event
        grabInteractable.WhenPointerEventRaised += HandlePointerEvent;
    }

    private void HandlePointerEvent(PointerEvent @event)
    {
        if (@event.Type == PointerEventType.Select)
        {
            isGrabbed = true;
        }
        else if (@event.Type == PointerEventType.Unselect)
        {
            isGrabbed = false;
            StopSpawning();
        }
    }

    void Update()
    {
        // Überprüfen ob das Objekt gehalten wird und die A-Taste gedrückt ist
        if (isGrabbed && OVRInput.GetDown(OVRInput.Button.One))
        {
            Debug.LogWarning("A-Taste wurde gedrückt, während das Objekt gehalten wurde!");
            StartSpawning();
        }
        else if (OVRInput.GetUp(OVRInput.Button.One))
        {
            StopSpawning();
        }
    }

    private void StartSpawning()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            StartCoroutine(SpawnObjects());
        }
    }

    private void StopSpawning()
    {
        if (isSpawning)
        {
            isSpawning = false;
            StopCoroutine(SpawnObjects());
        }
    }

    private IEnumerator SpawnObjects()
    {
        while (isSpawning)
        {
            Instantiate(prefabToSpawn, spawnPosition.position, spawnPosition.rotation);
            yield return new WaitForSeconds(0.01f); // Intervall zwischen den Spawns
        }
    }

    void OnDestroy()
    {
        // Entferne den Event Listener
        if (grabInteractable != null)
        {
            grabInteractable.WhenPointerEventRaised -= HandlePointerEvent;
        }
    }
}
