using UnityEngine;
using System.Collections;

public class creditos : MonoBehaviour {

    private float tempo;
    public Transform target;
    private bool guiLiberado;
    private bool creditosLiberado;

    void Start()
    {
        Invoke("liberarCreditos", 2.0f);
    }
    
    private void liberarCreditos()
    {
        creditosLiberado = true;
    }
    
    void Update () {

        if (creditosLiberado)
        {
            float distance = Vector3.Distance(transform.position, target.position);

            tempo += Time.deltaTime;

            if (distance > 0 && tempo >= 0.02f)
            {
                tempo = 0;
                transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 1 / distance);

                if (transform.position == target.position)
                {
                    guiLiberado = true;
                }
            }
        }       
	}

    void OnGUI()
    {
        if (guiLiberado)
        {
            if (GUI.Button(new Rect(10, 10, 130, 25), "MENU PRINCIPAL"))
            {
                Application.LoadLevel("Menu");
            }

            else if (GUI.Button(new Rect(10, 50, 130, 25), "SAIR"))
            {
                Application.Quit();
            }
        }    
    }
}
