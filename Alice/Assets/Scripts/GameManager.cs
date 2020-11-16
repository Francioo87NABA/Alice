using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;
    
    public bool start;

    private void OnEnable()
    {
        Singleton = this;
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}
