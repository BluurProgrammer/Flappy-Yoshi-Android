using UnityEngine;

public class Yoshi : MonoBehaviour {

    public float jumpForce;

	public GameObject prefabFogo;
	public GameObject prefabGelo;
    public GUITexture botaoPulo;
    public GUITexture botaoPower;
    public GUITexture botaoPause;

    private Controle controlador;
    public bool morto;
    private Rigidbody2D rb;
    private Animator animator;

    public PlayerPower PlayerPower { get; private set; }

    private PolygonCollider2D polyCollider2D;
   
    //properties
    public int FogoCount;
    public int GeloCount;

    void Awake()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            controlador = new ControleAndroid();
        }
        else
        {
            desativarBotoesMobile();
            controlador = new ControlePc();
        }      
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        polyCollider2D = GetComponent<PolygonCollider2D>();
        PlayerPower = GetComponent<PlayerPower>();

        FogoCount = 10;
    }

    void Update () {

         if (morto)
            return;
              
          controlador.controle(this);       
    }

    void OnBecameInvisible()
    {       
        if (enabled)
        {
            enabled = false;
            morte();
        }
    }

    public void setEspecialEstrela()
    {
        transform.gameObject.tag = "isEspecialEstrela";

        AudioManager.Instance.audioSource.Stop();
        AudioManager.Instance.PlayAudio("invensivel");

        PlayerPower.powerBarRenderer.enabled = false;

        animator.SetBool("especialEstrela", true);
        Invoke("voltarAoSpriteVoando", 12.0f);
    }

    public void voltarAoSpriteVoando()
    {
        AudioManager.Instance.audioSource.Play();
        transform.gameObject.tag = "Player";
        PlayerPower.powerBarRenderer.enabled = true;
        animator.SetBool("especialEstrela", false);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (transform.gameObject.tag == "isEspecialEstrela")
            return;

        if (!morto && coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Bala" || coll.gameObject.tag == "EnemySemAnimacao")
        {
            morte();
        }
    }

    private void morte()
    {
        if (morto)
            return;

        morto = true;

        AudioManager.Instance.audioSource.Stop();
        AudioManager.Instance.PlayAudio("morreu");

        polyCollider2D.isTrigger = true;

        transform.eulerAngles = new Vector3(0, 0, -120);
        Invoke("cenaGameOver", 2.0f);
    }

    private void cenaGameOver()
    {
        Application.LoadLevel("Game Over");
    }

    public void ataque()
    {
        if (!morto && transform.gameObject.tag != "isEspecialEstrela")
        {
            PlayerPower.updatePowerBar();

            if (FogoCount > 0)
            {
                animacaoPoder();
                Instantiate(prefabFogo, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.identity);
                FogoCount--;
            }

            else if (GeloCount > 0)
            {
                animacaoPoder();
                Instantiate(prefabGelo, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.identity);
                GeloCount--;
            }
        }
    }

    public void pular()
    {
        if (!morto)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(transform.up * jumpForce);
            AudioManager.Instance.PlayAudio("jump");
        }
    }

    private void animacaoPoder()
    {
        animator.SetBool("poder", true);
        Invoke("animacaoVoando", 0.11f);
    }

    private void animacaoVoando()
    {
        animator.SetBool("poder", false);
    }

    private void desativarBotoesMobile()
    {
        Destroy(botaoPulo);
        Destroy(botaoPower);
        Destroy(botaoPause);
    }
}
