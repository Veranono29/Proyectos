using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task5CirculoBotones : MonoBehaviour
{

    int[] bitMap= { 0, 0, 0, 0, 0,0};  //Cuales han sido pulsados

    [SerializeField]
    Sprite spriteMalo; //El boton pulsado

    [SerializeField]
    Sprite spriteBueno; //El boton pulsado

    
    public void pulsarBoton(Button p)
    {
        if (p.image.sprite.Equals(spriteMalo))
        {
            //Saco un nuevo array de la lista y se lo entrego al SpriteRenderer
            
            p.image.sprite = spriteBueno; //Cambio el sprite

            Debug.Log("pre parseo");
            int ind = int.Parse(p.GetComponentInChildren<Text>().text);
            
            print("postParseo");
            bitMap[ind] = 1;                        //Relleno el bitmap
            print("post bitMap");                    //Compruebo victoria
            if (comprobarVictoria())
            {
                fin();
            }

        }
        else { print("Boton ya tocado"); }
    }

    private bool comprobarVictoria()
    {
        bool total = true;
        for (int i = 0; i < 6; ++i)
        {
            if (bitMap[i] == 0)
            {
                total = false;
            }
        }
        return total;
    }

    private void fin()
    {
        TaskManager.instance.FinishTask(true);
    }

    
    

   

}
