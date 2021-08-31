using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameSwitch : MonoBehaviour
{
    public GameObject activeFrame;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            activeFrame.SetActive(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            activeFrame.SetActive(false);
        }
    }
}
