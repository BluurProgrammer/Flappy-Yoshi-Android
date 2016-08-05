using UnityEngine;
using System.Collections;

public class MoverObjeto : MonoBehaviour {

	
	public float velocidade;

	void Start () {
	
	}
	

	void Update () {
	
		GetComponent<Rigidbody2D>().velocity = new Vector2(velocidade, 0);

	}
}
