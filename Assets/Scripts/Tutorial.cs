using UnityEngine;

public class Tutorial : MonoBehaviour {

    public GameObject tutorial;
    private bool apertou;
    private bool liberado;

	void Start ()
    {
        Invoke("liberarJogo", 8.0f);
	}

    void Update()
    {
        if (Input.anyKeyDown && liberado)
        {
            if (!apertou)
            {
                apertou = true;
                Application.LoadLevel("Flappy Yoshi");
            }
        }
    }

    private void liberarJogo()
    {
        liberado = true;
        tutorial.SetActive(true);       
    }
}
