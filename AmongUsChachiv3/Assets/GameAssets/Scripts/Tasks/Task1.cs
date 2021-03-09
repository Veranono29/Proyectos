using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task1 : MonoBehaviour
{
    [SerializeField]
    Text progressText;

    [SerializeField]
    Image progressBar;

    bool isClearing = false;

    float _amount;

    public float amount
    {
        get
        {
            return _amount;
        }
        set
        {
            if (value > 100)
            {
                _amount = 100;
            }
            else
            {
                _amount = value;
            }
            ActualiceBar();
        }
    }

    public void Init()
    {
        StopAllCoroutines();
        amount = 0;
        progressBar.fillAmount = 0;
        isClearing = false;
    }

    void ActualiceBar()
    {
        progressBar.fillAmount = amount / 100;
        progressText.text = amount.ToString() + "%";
    }

    public void StartCleaning()
    {
        if (!isClearing)
        {
            StartCoroutine(Clear());
            isClearing = true;
        }

    }

    IEnumerator Clear()
    {
        yield return new WaitForSeconds(0.1f);
        amount += 2;

        if (amount >= 100)
        {
            TaskManager.instance.FinishTask(true);
        }
        else
        {
            StartCoroutine(Clear());
        }
    }
}
