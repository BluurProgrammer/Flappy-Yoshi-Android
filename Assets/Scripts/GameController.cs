using UnityEngine;

public enum GAMESTAT
{
    MENU,
    TUTORIAL,
    GAME,
    END,
    GAMEOVER,
}

public class GameController : MonoBehaviour {

    public static GameController INSTANCE { get; private set; }

    public GAMESTAT GameStat { get; set; }
    
    void Awake()
    {
        if (INSTANCE != null && INSTANCE != this)
        {
            Destroy(gameObject);
        }

        INSTANCE = this;
    }

    void Start()
    {
        GameStat = GAMESTAT.MENU;
    }

    public void sair()
    {
        Application.Quit(); 
    }

    private void enter()
    {
        AudioManager.Instance.audioSource.Stop();
        AudioManager.Instance.PlayAudio("enter");
    }

    public void jogar()
    {
        enter();
        Invoke("cenatutorial", 0.5f);
    }

    public void fase1()
    {
        enter();
        Invoke("cenaFlappyYoshi", 0.5f);
    }

    private void cenatutorial()
    {
        Application.LoadLevel("tutorial");
    }

    private void cenaFlappyYoshi()
    {
        //Application.LoadLevel(Application.loadedLevel);
        Application.LoadLevel("Flappy Yoshi");
    }
}
