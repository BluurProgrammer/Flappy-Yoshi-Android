using UnityEngine;
using System.Collections;
using System;

public class ControleAndroid : Controle
{
    public override void controle(Yoshi player)
    {
        if (Input.touches.Length > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (player.botaoPulo.HitTest(Input.GetTouch(i).position))
                {
                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                    {
                        player.pular();
                    }
                }

                if (player.botaoPower.HitTest(Input.GetTouch(i).position))
                {
                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                    {
                        player.ataque();
                    }
                }

                if (player.botaoPause.HitTest(Input.GetTouch(i).position))
                {
                    GameObject.FindObjectOfType<PauserGame>().pausar();
                }
            }
        }
    }
}
