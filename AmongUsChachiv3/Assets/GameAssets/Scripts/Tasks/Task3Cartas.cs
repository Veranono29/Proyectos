using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task3Cartas : MonoBehaviour
{
    [SerializeField]
    Sprite spriteMalo;
    //public SpriteRenderer spriteRenderer;
    public Sprite[] newSprite;              //array con los sprites posibles
    private Sprite[] spritesSacados = new Sprite[10];         //array de todos los arrasy qeu han salido ya
    private int tamArray = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void darCartaRandom(Button spr)
    {
        if (spr.image.sprite.Equals(spriteMalo))
        {
            //Saco un nuevo array de la lista y se lo entrego al SpriteRenderer
            spr.image.sprite = newSprite[(int)UnityEngine.Random.Range(1, newSprite.Length)];
            spritesSacados[tamArray] = spr.image.sprite;

            
            comprobarVictoria();
            tamArray++;
        }
        else { print("Carta ya volteada"); }
    }

    private void comprobarVictoria()
    {
        if (tamArray > 2)
        {
            for (int i = 0; i < tamArray; ++i)
            {
                if (spritesSacados[i].Equals(spritesSacados[tamArray]))
                {

                    Invoke("fin",2);
                    print("done");
                }
                else {
                    print("Prueba otra vez");
                }
            }
        }
    }

    private void fin()
    {
        TaskManager.instance.FinishTask(true);
    }
    
}
