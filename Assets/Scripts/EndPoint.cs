﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject changeLevelPanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameController.TogglePanels(changeLevelPanel);
            GameController.TogglePause();
        }
    }
}
