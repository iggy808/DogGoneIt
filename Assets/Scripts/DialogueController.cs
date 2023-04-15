using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class DialogueController : MonoBehaviour
{
    public GameObject Owner;

    ThirdPersonController OwnerMovement;


    void Start()
    {
        OwnerMovement = Owner.GetComponent<ThirdPersonController>();
    }

    public void BeginOldManDialogue()
    {
        Debug.Log("Old man dialogue beginning");
        EndOndManDialogue();
    }

    void EndOndManDialogue()
    {
        Debug.Log("Old man dialogue over");
        OwnerMovement.enabled = true;
    }
}
