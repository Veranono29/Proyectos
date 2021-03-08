using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task0 : MonoBehaviour
{
    [SerializeField]
    Text progressText;

    [SerializeField]
    Image progressBar;

    bool isDownloading = false;

    float _amount;
    
    public float amount {
        get {
            return _amount;
        }
        set {
            if (value > 100)
            {
                _amount = 100;
            }
            else {
                _amount = value;
            }
            ActualiceBar();
        }
    }

    public void Init() {
        StopAllCoroutines();
        amount = 0;
        progressBar.fillAmount = 0;
        isDownloading = false;
    }

    void ActualiceBar() {
        progressBar.fillAmount = amount / 100;
        progressText.text = amount.ToString()+"%";
    }

    public void StartDownload() {
        if (!isDownloading)
        {
            StartCoroutine(Download());
            isDownloading = true;
        }
    
    }

    IEnumerator Download()
    {
        yield return new WaitForSeconds(0.1f);
        amount += 2;

        if (amount >= 100)
        {
            TaskManager.instance.FinishTask(true);
        }
        else {
            StartCoroutine(Download());
        }
    }
}
