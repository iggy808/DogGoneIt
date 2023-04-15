using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;



public class DogController : MonoBehaviour
{
    GameObject Owner;
    CharacterController characterController;
    ThirdPersonController thirdPerson;

    public bool IsFound;
    public bool IsFollowing;
    public bool IsControlled;

    // Start is called before the first frame update
    void Start()
    {
        Owner = GameObject.FindGameObjectWithTag("Player");
        characterController = GetComponent<CharacterController>();
        thirdPerson = GetComponent<ThirdPersonController>();

        characterController.enabled = false;
        thirdPerson.enabled = false;

        IsFound = false;
        IsFollowing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFollowing)
        {
            transform.position = new Vector3(Owner.transform.position.x-2, Owner.transform.position.y+1, Owner.transform.position.z-2);
            transform.rotation = Owner.transform.rotation;
        }
        else if (!IsFound && Vector3.Distance(Owner.transform.position, transform.position) < 1)
        {
            IsFollowing = true;
            IsFound = true;
        }
    }
}
