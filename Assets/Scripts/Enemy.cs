using UnityEngine;

public class Enemy : MonoBehaviour {

    private float y;
    private float x;

    public float speed;
   
    public int life;
    private Score score;
    private Animator animator;
    private Vector2 screenPosition;
    public bool dupla;

    private Yoshi yoshi;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Awake()
    {   
        if (!dupla)
        {
            yoshi = FindObjectOfType(typeof(Yoshi)) as Yoshi;

            y = yoshi.transform.position.y;
            transform.position = new Vector2(transform.position.x, y);
        }
        else
            transform.position = new Vector2(transform.position.x, transform.position.y);

        score = GameObject.Find("SCORE").GetComponent<Score>();
    }

    void OnBecameInvisible()
    {
        Destroy(transform.gameObject);
    }

    #region verificaPosicao
    //private void verificaPosicao()
    // {
    // screenPosition = Camera.main.WorldToScreenPoint(transform.position);

    // if (screenPosition.x <= -20)
    //  {
    // Destroy(transform.gameObject);
    // }
    // }
    #endregion

    void Update()
    {
       //verificaPosicao();
  
        movimentar();

        if (life <= 0)
            cair();
    }

    private void movimentar()
    {
        x = transform.position.x;
        x -= speed * Time.deltaTime;

        if (!dupla)
            transform.position = new Vector2(x, y);
        else
            transform.position = new Vector2(x, transform.position.y);
    }

    private void cair()
    {
        y = transform.position.y;
        y -= 2.5f * Time.deltaTime;
        transform.position = new Vector2(x, y);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
		bool fogoYoshi = coll.gameObject.tag == "FogoYoshi";
		bool geloYoshi = coll.gameObject.tag == "GeloYoshi";
        bool enemySemAnimacao = this.gameObject.tag == "EnemySemAnimacao";
        bool playerEspecialEstrela = coll.gameObject.tag == "isEspecialEstrela";

        if (fogoYoshi || geloYoshi || playerEspecialEstrela)
        {
            AudioManager.Instance.PlayAudio("colide");

            if (playerEspecialEstrela)
                life = 0;
            else
               life--;

            if (life <= 0)
            {
                GetComponent<Collider2D>().isTrigger = true;
                
                if (enemySemAnimacao)
                {
                    animator.SetBool("trocaSprite", true);
                }

                else if (fogoYoshi || playerEspecialEstrela)
                {
                        animator.SetBool("explodeFogo", true);

                        if (gameObject.tag == "Bala")
                        {
                            Invoke("desativarObjeto", 0.4f);
                        }
                        else
                        {
                            Invoke("morteSpriteFogo", 0.3f);
                        }
                }

                else if (geloYoshi || playerEspecialEstrela)
                {
                        animator.SetBool("explodeGelo", true);

                        if (gameObject.tag != "Bala")
                        {
                            Invoke("morteSpriteGelo", 0.3f);
                        }
                }
                                      
                score.addPonto(1);
            }
            
            if (!playerEspecialEstrela)                             
                coll.gameObject.SetActive(false);
        }
    }

    private void desativarObjeto()
    {
        gameObject.SetActive(false);
    }

	private void morteSpriteFogo()
	{
        animator.SetBool("morteFogo", true);       
    }

	private void morteSpriteGelo()
	{
        animator.SetBool("morteGelo", true);		
	}
}
