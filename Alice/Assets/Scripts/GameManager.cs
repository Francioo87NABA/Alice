using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;
    
    public bool start;
    public bool dentroPorta1;

    public GameObject porta1;
    public Transform transformPorta1;
    private Animator animatorPorta1;

    private int one;
    private int two;
    

    private void OnEnable()
    {
        Singleton = this;
    }

    void Start()
    {
        animatorPorta1 = porta1.GetComponentInChildren<Animator>();
    }
    
    void Update()
    {
        if (one == 0 && start)
        {
            StartCoroutine(Sequenza1());
            one++;
        }

        if (two == 0 && dentroPorta1)
        {
            StartCoroutine(Sequenza2());
            two++;
        }
        
        
            
    }

    IEnumerator Sequenza1()
    {
        //instanzia audio
        
        yield return new WaitForSeconds(5f); //DEVE ESSERE 15 SECONDI
        
        porta1.SetActive(true);
        porta1.transform.position = transformPorta1.position;
        
        yield return new WaitForSeconds(5f);
        
        animatorPorta1.SetBool("Apriti",true);
    }

    IEnumerator Sequenza2()
    {
        //Instanzia audio
        
        yield return new WaitForSeconds(5f);
        
        animatorPorta1.SetBool("Apriti", false);
    }
}
