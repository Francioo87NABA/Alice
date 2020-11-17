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

    public AudioSource sequenza1;
    public AudioSource sequenza2;

    public GameObject player;
    
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
        yield return new WaitForSeconds(5f);
        
        sequenza1.transform.position = player.transform.position;
        sequenza1.gameObject.SetActive(true);

        yield return new WaitForSeconds(15f); 
        
        porta1.SetActive(true);
        porta1.transform.position = transformPorta1.position;
        
        yield return new WaitForSeconds(5f);
        
        animatorPorta1.SetBool("Apriti",true);
    }

    IEnumerator Sequenza2()
    {
        sequenza2.transform.position = player.transform.position;
        sequenza2.gameObject.SetActive((true));

        yield return new WaitForSeconds(5f);
        
        animatorPorta1.SetBool("Apriti", false);
    }
}
