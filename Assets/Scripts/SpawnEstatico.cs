using UnityEngine;
using System.Collections;

public class SpawnEstatico : MonoBehaviour {

  
    public GameObject[] objetos;
    public Vector2[] posicoes;
    public bool sincronizarIndex;

    public float timeSpawn;
    public float delaySpawn;
    public float range;

    void Start () {
        InvokeRepeating("spawn", delaySpawn, timeSpawn);
    }

    private void spawn()
    {
        int inimigoIndex = Random.Range(0, objetos.Length);
        int posicaoIndex = Random.Range(0, posicoes.Length);

        if (sincronizarIndex)
        {
            posicaoIndex = inimigoIndex;            
        }
      

        Instantiate(objetos[inimigoIndex], posicoes[posicaoIndex], Quaternion.identity);       
    }
}
