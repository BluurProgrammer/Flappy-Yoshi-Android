using UnityEngine;

public class PauserGame : MonoBehaviour {

    private static bool isPauseGame;
 
    public void pausar()
    {          
            if (isPauseGame)
            {             
                AudioManager.Instance.audioSource.Play();
                Time.timeScale = 1;
                isPauseGame = false;
            }
            else
            {
                AudioManager.Instance.audioSource.Stop();
                Time.timeScale = 0;
                isPauseGame = true;
            }
            AudioManager.Instance.PlayAudio("Pause");
    }
}
