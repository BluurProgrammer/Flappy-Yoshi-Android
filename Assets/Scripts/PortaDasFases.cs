using UnityEngine;
using System.Collections;

public class PortaDasFases : MonoBehaviour {

    public float velocidade;
    private GameObject fase;

    void Start()
    {
        fase = GameObject.Find("proximafase");
    }

	void Update () {
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocidade, 0);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "isEspecialEstrela")
        {
            fase.GetComponent<ProximaFase>().proximaFase();
        }
        else
        {
            coll.gameObject.SetActive(false);
        }  
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 130, 25), "PRÓXIMA FASE!!!"))
        {
            fase.GetComponent<ProximaFase>().proximaFase();
        }
    }
}
