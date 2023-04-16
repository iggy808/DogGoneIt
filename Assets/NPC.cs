using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogueTrigger trigger;
    private RectTransform backgroundBox;


    void Start()
    {
        backgroundBox = GameObject.FindGameObjectWithTag("DialogueBox").GetComponent<RectTransform>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") == true)
        {
            trigger.StartDialogue();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") == true)
        {
            backgroundBox.LeanScale(Vector3.zero, 0.5f);
            //backgroundBox.transform.localScale = Vector3.zero;
        }
    }
    
}
