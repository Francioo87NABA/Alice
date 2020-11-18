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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (porta1)
            {
                GameManager.Singleton.dentroPorta1 = true;
            }
            else if (porta2)
            {
                GameManager.Singleton.dentroPorta2 = true;
            }
            else if (porta3)
            {
                GameManager.Singleton.dentroPorta3 = true;
            }
            else if (fuoriPorta1)
            {
                GameManager.Singleton.fuoriPorta1 = true;
            }
        }
       
    }
}
