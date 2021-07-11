using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimator : MonoBehaviour
{
    public Animator startButtonAnimator;
    public DialogueManager dialogueManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        startButtonAnimator.SetBool("startOpen", true);
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        startButtonAnimator.SetBool("startOpen", false);
        dialogueManager.EndDialogue(); 
    }
}
