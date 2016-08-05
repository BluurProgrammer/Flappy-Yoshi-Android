using UnityEngine;
using System.Collections;

public class ItemPoder : MonoBehaviour {

    private float y;
    private float x;
    private Yoshi yoshi;
    private Vector2 screenPosition;
    public float speed;

    void Start()
    {
        yoshi = FindObjectOfType(typeof(Yoshi)) as Yoshi;

        y = yoshi.transform.position.y;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }

    private void verificaPosicaoParaDestruir()
    {
        screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPosition.x <= -20)
        {
            Destroy(transform.gameObject);
        }
    }

    void Update()
    {
        verificaPosicaoParaDestruir();
        movimentar();
    }

    private void movimentar()
    {
        x = transform.position.x;
        x -= speed * Time.deltaTime;
        transform.position = new Vector2(x, y);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Player") && !coll.gameObject.tag.Equals("isEspecialEstrela"))
        {
            if (this.gameObject.tag.Equals("ItemEstrela") && GameController.INSTANCE.GameStat != GAMESTAT.END)
            {          
                yoshi.setEspecialEstrela();
            }

			else if (this.gameObject.tag.Equals("ItemFogo"))
			{
                yoshi.GeloCount = 0;

                if (yoshi.FogoCount <= 0)
                {
                    yoshi.PlayerPower.reiniciarBar();
                }

                yoshi.FogoCount = 10;
                yoshi.PlayerPower.powerBarRenderer.material.color = Color.red;
                             
            }
			else if (this.gameObject.tag.Equals("ItemGelo"))
			{
                yoshi.FogoCount = 0;

                if (yoshi.GeloCount <= 0)
                {
                    yoshi.PlayerPower.reiniciarBar();
                }

                yoshi.GeloCount = 10;
                yoshi.PlayerPower.powerBarRenderer.material.color = Color.blue;                          
            }

            AudioManager.Instance.PlayAudio("pegouItem");
            gameObject.SetActive(false);      
        }
    }
}
