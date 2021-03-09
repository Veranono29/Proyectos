using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task2 : MonoBehaviour
{
    [SerializeField]    //se usará para mostrar los numeros introducidos
    Text display;

    [SerializeField]    //se usará para mostrar los numeros introducidos
    Text contrasena;

   

    private void Start()
    {
        createPassword();
    }
    public void nextNumber(string number)
    {
        if (display.text.Length < 4)
        {
            display.text += number;
        }
    }
    public void isCorrect()
    {
        if(display.text.Equals(contrasena.text))
        {
            TaskManager.instance.FinishTask(true);
        }
        else
        {
            // Borrar el texto después de 2 segundos
            display.text = "Error";
            Invoke("EraseNumbers", 2);
        }
    }
    
    public void EraseNumbers()
    {
        display.text = "";
    }
    private void createPassword()
    {
        //me aseguro que no hay nada
        contrasena.text = "";
        //creo 4 numoers aleatorios 
        contrasena.text += (int) (UnityEngine.Random.value*10000-1);
        
    }
}
