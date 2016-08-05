using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnInimigos : MonoBehaviour {

    public GameObject[] inimigos;
    public float timeSpawn;
    public float delaySpawn;

	void Start () {
        InvokeRepeating("spawn", delaySpawn, timeSpawn);
	}
	
	private void spawn () {

        int inimigoIndex = Random.Range(0, inimigos.Length);

        Instantiate(inimigos[inimigoIndex], transform.position, Quaternion.identity);
	}
}
