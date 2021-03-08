using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskInteract : MonoBehaviour
{
    public bool isDone;
    public taskType type;

    public UnityEvent OnInicialice;

    public void InitTask()
    {
        OnInicialice.Invoke();
    }
}
