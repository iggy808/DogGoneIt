using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableTargetController : MonoBehaviour
{
    Rigidbody pushableRigidBody;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Pushable1")
        {
            Debug.Log("Object has entered goal zone");
            collider.gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("Ramp1").SetActive(true);
        }
    }
}
