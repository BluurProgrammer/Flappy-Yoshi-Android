using UnityEngine;
using System.Collections;

public class Seguir : MonoBehaviour {

    public string nomeTagParaSeguir;
    public Vector3 distancia; // distancia

    private Transform objeto;

	void Awake()
    {
        objeto = GameObject.FindGameObjectWithTag(nomeTagParaSeguir).transform;
    }
	
	
	void Update ()
    {
        transform.position = objeto.position + distancia;
	}
}
