using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task3 : MonoBehaviour
{
    [SerializeField] private GameObject back;

    public void OnMouseOver()
    {
        if (back.activeSelf)
        {
            back.SetActive(false);
        }
    }
}