using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task4Boton : MonoBehaviour
{
    [SerializeField]
    int veces;

    [SerializeField]
    Text Titulo;
    [SerializeField]
    Text Pulsadas;

    private int llevo = 0;
    
    // Start is called before the first frame update
    public void Start()
    {
        pep();
    }
    
    public void pep()
    {
        llevo = 0;

        Pulsadas.text = llevo.ToString();
    }
  public void pulsar()
    {
        if (veces > llevo+1)
        {
            llevo++;
            Pulsadas.text = llevo.ToString();
        }
        else
        {
            TaskManager.instance.FinishTask(true);
        }

    }
}
