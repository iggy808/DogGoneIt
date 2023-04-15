using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class PlayerInteractionManager : MonoBehaviour
{
    public bool CanTalkWithOldMan;
    public DialogueController dialogueController;
    GameObject Owner;
    public bool DialogueIsOver;
    int NumberOfTalks;

    StarterAssetsInputs _input;

    void Start()
    {
        DialogueIsOver = false;
        CanTalkWithOldMan = false;
        NumberOfTalks = 0;
        Owner = GameObject.FindGameObjectWithTag("Player");
        _input = Owner.GetComponent<StarterAssetsInputs>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "OldMan")
        {
            Debug.Log("Player is within window dialogue trigger");
            CanTalkWithOldMan = true;
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (_input.talk && CanTalkWithOldMan && !DialogueIsOver)
        {
            Debug.Log("You are attempting to talk to the old man");
            Owner.GetComponent<ThirdPersonController>().enabled = false;
            SendDialogue(collider.gameObject.tag);
            _input.talk = false;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "OldMan")
        {
            Debug.Log("Player has exited window dialogue trigger");
            CanTalkWithOldMan = false;
        }
    }

    void SendDialogue(string objectTag)
    {
        switch (objectTag)
        {
            case "OldMan":
                dialogueController.BeginOldManDialogue();
                break;
            default:
                break;
        }
    }
}
