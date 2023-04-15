using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovementController : MonoBehaviour
{
    GameObject Owner;
    bool IsFound;
    bool IsFollowing;
    bool IsControlled;

    // Start is called before the first frame update
    void Start()
    {
        Owner = GameObject.FindGameObjectWithTag("Player");
        IsFound = false;
        IsFollowing = false;
        IsControlled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFollowing)
        {
            transform.position = new Vector3(Owner.transform.position.x-2, Owner.transform.position.y+1, Owner.transform.position.z-2);
            transform.rotation = Owner.transform.rotation;
        }
        else if (IsControlled)
        {

        }
        else if (!IsFound && Vector3.Distance(Owner.transform.position, transform.position) < 1)
        {
            IsFollowing = true;
            IsFound = true;
        }
    }
}
