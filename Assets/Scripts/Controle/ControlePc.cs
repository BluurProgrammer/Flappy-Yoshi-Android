using UnityEngine;
using System.Collections;
using System;

public class ControlePc : Controle {

    public override void controle(Yoshi player)
    {
        if (Input.GetKeyDown (KeyCode.Space))
        {
			player.pular ();            
		}
        else  if (Input.GetMouseButtonDown (0))
        {
              player.ataque();
		}

        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject.FindObjectOfType<PauserGame>().pausar();
        }
    }
}
