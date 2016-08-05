using UnityEngine;
using System.Collections;

public class SpawnItems : MonoBehaviour {

    public GameObject[] items;

    public float timeSpawn;
    public float delaySpawn;

    void Start()
    {
        InvokeRepeating("spawn", delaySpawn, timeSpawn);
    }

    private void spawn()
    {
        int itemIndex = Random.Range(0, items.Length);
        int chance = Random.Range(0, 100);

        if (chance >= 60)
            Instantiate(items[itemIndex], transform.position, Quaternion.identity);
    }
}
