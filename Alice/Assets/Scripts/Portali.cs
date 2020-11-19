using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portali : MonoBehaviour
{
    public bool portaleMondo1;
    public bool portaleMondo2;

    public GameObject filtroCameraMondo1;
    public GameObject filtroCameraMondo2;
    public GameObject filtroCameraMondo3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (portaleMondo1)
            {
                filtroCameraMondo1.SetActive(true);
            }
            else if (portaleMondo2)
            {
                filtroCameraMondo2.SetActive(true);
            }
            else
            {
                filtroCameraMondo3.SetActive(true);
            }
        }
    }
}
