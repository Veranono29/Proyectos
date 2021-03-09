using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task1 : MonoBehaviour
{
    [SerializeField]
    Text titulo;

    public void pushBoton(Button boton)
    {
        titulo.text = "BASURA TIRADA";
        boton.transform.Rotate(0,0, 180);
        Invoke("done",2);

    }
    private void done()
    {
        TaskManager.instance.FinishTask(true);
    }
   
    
}
