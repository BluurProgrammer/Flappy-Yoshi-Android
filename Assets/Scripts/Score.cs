using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    public int score = 0;
 
    private void atualizaPontuacao()
    {
        GetComponent<GUIText>().text = "Score: "+ score.ToString();
    }

    public void addPonto(int valorPonto)
    {
        score += valorPonto;
        atualizaPontuacao();
    }
}
