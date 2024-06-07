using UnityEngine;
using System.Collections;


public class DespawnAfterTime : MonoBehaviour
{
    public float despawnTime = 2.0f; // Zeit in Sekunden, nach der das Objekt gelöscht wird

    void Start()
    {
        // Starte die Coroutine, die das Objekt nach einer bestimmten Zeit löscht
        StartCoroutine(Despawn());
    }

    private IEnumerator Despawn()
    {
        // Warte für die angegebene Zeit
        yield return new WaitForSeconds(despawnTime);

        // Lösche das GameObject
        Destroy(gameObject);
    }
}