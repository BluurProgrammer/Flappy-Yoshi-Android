using UnityEngine;
using System.Collections;

public class PlayerPower : MonoBehaviour {

    public SpriteRenderer powerBarRenderer;
    private Vector3 powerScaleAtual;
  
	void Awake () {

        powerBarRenderer = GameObject.Find("PowerBar").GetComponent<SpriteRenderer>();
        powerScaleAtual = powerBarRenderer.transform.localScale;
       
    }

    public void updatePowerBar()
    {
        if (powerScaleAtual.x <= 0)
        {
            if (powerBarRenderer.enabled)
                powerBarRenderer.enabled = false;

            return;
        }

        powerBarRenderer.transform.localScale = new Vector3(powerScaleAtual.x -= 0.10f , 1, 1);
    }

    public void reiniciarBar()
    {
        if (!powerBarRenderer.enabled)
            powerBarRenderer.enabled = true;

        powerBarRenderer.transform.localScale = new Vector3(1, 1, 1);
    }
}
