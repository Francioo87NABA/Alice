using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{

    public bool porta1;
    public bool fuoriPorta1;
    public bool fuoriPorta2;
    public bool fuoriPorta3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (porta1)
            {
                GameManager.Singleton.dentroPorta1 = true;
            }
            else if (fuoriPorta1)
            {
                GameManager.Singleton.fuoriPorta1 = true;
            }
            else if (fuoriPorta2)
            {
                GameManager.Singleton.fuoriPorta2 = true;
            }
            else if (fuoriPorta3)
            {
                GameManager.Singleton.fuoriPorta3 = true;
            }
        }
       
    }
}
