using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    public bool porta1;
    public bool porta2;
    public bool porta3;
    public bool fuoriPorta1;
    public bool fuoriPorta2;
    public bool fuoriPorta3;

    public GameObject filtroCameraMondo1;
    public GameObject filtroCameraMondo2;
    public GameObject filtroCameraMondo3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (porta1)
            {
                GameManager.Singleton.dentroPorta1 = true;
                filtroCameraMondo1.SetActive(true);
            }
            else if (porta2)
            {
                filtroCameraMondo2.SetActive(true);
            }
            else if (porta3)
            {
                filtroCameraMondo3.SetActive(true);
            }
            else if (fuoriPorta1)
            {
                GameManager.Singleton.fuoriPorta1 = true;
                filtroCameraMondo1.SetActive(false);
            }
            else if (fuoriPorta2)
            {
                GameManager.Singleton.fuoriPorta2 = true;
                filtroCameraMondo2.SetActive(false);
            }
            else if (fuoriPorta3)
            {
                GameManager.Singleton.fuoriPorta3 = true;
                filtroCameraMondo3.SetActive(false);
            }
        }
       
    }
}
