using UnityEngine;
using System.Collections;

public class MoveCenario : MonoBehaviour {

	private Material material;
	private float offset;
	public float velocidade;

    void Start () {
		material = GetComponent<Renderer>().material;
	}

	void Update ()
    {
        if (Time.timeScale != 1)
        {
            return;
        }
         offset += 0.001f;
         material.SetTextureOffset("_MainTex", new Vector2(offset*velocidade,0));
    }
}
