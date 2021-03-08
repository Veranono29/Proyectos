using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerInteract : NetworkBehaviour
{
    protected TaskInteract task;

    private void OnTriggerEnter(Collider other)
    {
        var nearbyTask = other.GetComponent<TaskInteract>();
        if (nearbyTask && isLocalPlayer)
        {
            if (nearbyTask.isDone == false) {
                this.task = nearbyTask;
                TaskManager.instance.ActivateInteractPanel(true);

            }
            
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (task != null) {
            if (Input.GetKeyDown(KeyCode.Space) && task.isDone == false)
            {
                TaskManager.instance.DoTask(task);
                TaskManager.instance.ActivateInteractPanel(false);
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        var nearbyTask = other.GetComponent<TaskInteract>();
        if (nearbyTask && isLocalPlayer)
        {
            if (nearbyTask.isDone == false)
            {
                this.task = null;
                TaskManager.instance.ActivateInteractPanel(false);
                TaskManager.instance.FinishTask(false);
            }
        }
    }
     
}
