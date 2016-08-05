using UnityEngine;
using System.Collections;

public class MoverPoder : MonoBehaviour {

    public float velocidade;
    private Vector2 screenPosition;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        AudioManager.Instance.PlayAudio("flames");
    }

    private void verificaPosicaoParaDestruir()
    {
        screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPosition.x > Screen.width)
        {
            Destroy(transform.gameObject);
        }
    }

    void Update ()
    {
        verificaPosicaoParaDestruir();
        rb.velocity = new Vector2(velocidade, 0);
	}
}
