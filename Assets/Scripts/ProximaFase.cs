using UnityEngine;
using System.Collections;

public class ProximaFase : MonoBehaviour {

    public GameObject[] objetosParaDesativar;
    public string nomeDaProximaFase;
    public float tempoParaProximaFase;
    public int pontosNecessarios;
    public GameObject portaDasFases;

    private Score score; 
    private float timeInGame;
    private bool faseConcluida;

    void Start()
    {
        score = GameObject.Find("SCORE").GetComponent<Score>();
    }

	void Update () {

        timeInGame += Time.deltaTime;

        if (timeInGame >= tempoParaProximaFase && score.score >= pontosNecessarios && !faseConcluida)
        {
            faseConcluida = true;
            GameController.INSTANCE.GameStat = GAMESTAT.END;
            desativaComponentes();
            fimFase();
        }
	}
	
    private void fimFase()
    {
        AudioManager.Instance.audioSource.Stop();
        AudioManager.Instance.PlayAudio("finalFase");
        Instantiate(portaDasFases, transform.position, Quaternion.identity);
    }

    private void desativaComponentes()
    { 
        for (int i = 0; i < objetosParaDesativar.Length; i++ )
        {
            Destroy(objetosParaDesativar[i]);
        }      
    }

    public void proximaFase()
    {
        Application.LoadLevel(nomeDaProximaFase);
    }
}
