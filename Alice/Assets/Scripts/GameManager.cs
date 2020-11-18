using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;
    
    public bool start;
    public bool dentroPorta1;
    public bool dentroPorta2;
    public bool dentroPorta3;
    public bool fuoriPorta1;
    public bool monocoloY;
    public bool monocoloZ;

    public GameObject porta;
    public Transform portaTransform;
    public Transform cadavereTransform;
    
    public GameObject triggerPorta1;
    public GameObject triggerPorta2;
    public GameObject triggerPorta3;
    public GameObject triggerFuoriPorta1;

    public GameObject cadavere;
    
    private Animator animatorPorta;

    public GameObject player;
    
    public AudioSource sequenza1;
    public AudioSource sequenza2;
    public AudioSource sequenza3;
    public AudioSource sequenza4;
    public AudioSource sequenza5;
    
    private int one;
    private int two;
    private int three;
    private int four;
    

    private void OnEnable()
    {
        Singleton = this;
    }

    void Start()
    {
        animatorPorta = porta.GetComponentInChildren<Animator>();
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

        if (three == 0 && monocoloY && monocoloZ)
        {
            StartCoroutine(Sequenza3());
            three++;
        }

        if (four == 0 && fuoriPorta1)
        {
            StartCoroutine(Sequenza4());
            four++;
        }
        
        
            
    }

    IEnumerator Sequenza1()
    {
        yield return new WaitForSeconds(5f);
        
        sequenza1.transform.position = player.transform.position;
        sequenza1.gameObject.SetActive(true);

        yield return new WaitForSeconds(15f); 
        
        porta.transform.position = portaTransform.position;
        porta.SetActive(true);
        triggerPorta1.SetActive(true);
        
        yield return new WaitForSeconds(5f);
        
        animatorPorta.SetBool("Apriti",true);
    }

    IEnumerator Sequenza2()
    {
        //parte quando si entra dentro la porta1
        
        sequenza2.transform.position = player.transform.position;
        sequenza2.gameObject.SetActive((true));

        yield return new WaitForSeconds(5f);
        
        animatorPorta.SetBool("Apriti", false);
        
        triggerPorta1.SetActive(false);
    }

    IEnumerator Sequenza3()
    {
        //Parte quando vengono raccolti i due monocoli 
        
        sequenza3.transform.position = player.transform.position;
        sequenza3.gameObject.SetActive(true);
        
        triggerFuoriPorta1.SetActive(true);
        
        cadavere.transform.position = cadavereTransform.position;
        cadavere.SetActive(true);
        
        yield return new WaitForSeconds(10f);
        
        animatorPorta.SetBool("Apriti",true);
    }

    IEnumerator Sequenza4()
    {
        //Parte quando esci dalla porta1 e vedi il tuo cadavere

        sequenza4.transform.position = player.transform.position;
        sequenza4.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(2f);
        
        animatorPorta.SetBool("Apriti", false);
    }
}
