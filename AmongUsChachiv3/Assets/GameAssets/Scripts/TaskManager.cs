using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum taskType { DownloadData, Basura, Contrasena, Cartas, Boton,CiculoBotones }

public class TaskManager : MonoBehaviour
{
    public static TaskManager instance;
    [SerializeField]
    GameObject interactPanel;

    public List<GameObject> tasks = new List<GameObject>();

    TaskInteract actualTask;

    private void Awake()
    {
        instance = this;
    }

    public void ActivateInteractPanel(bool value ) {
        interactPanel.SetActive(value);
    }

    public void DoTask(TaskInteract theTask) {
        tasks[(int)theTask.type].SetActive(true);
        actualTask = theTask;
    }

    public void FinishTask(bool value)
    {
        if(actualTask != null)
        {
            actualTask.InitTask();
            actualTask.isDone = value;
            tasks[(int)actualTask.type].SetActive(false);
            actualTask = null;
        }
    }
}

