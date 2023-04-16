using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableTargetController : MonoBehaviour
{
    Rigidbody pushableRigidBody;
    GameObject ramp1;
    GameObject ramp2;
    GameObject ramp3;

    GameStateController GameStateController;

    public bool Pushable2_IsPushed;
    public bool Pushable3_IsPushed;

    void Awake()
    {
        ramp1 = GameObject.FindGameObjectWithTag("Ramp1");
        ramp2 = GameObject.FindGameObjectWithTag("Ramp2");
        ramp3 = GameObject.FindGameObjectWithTag("Ramp3");
    }

    void Start()
    {
        GameStateController = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameStateController>();
        if (ramp1.active)
        {
            ramp1.SetActive(false);
        }
        if (ramp2.active)
        {
            ramp2.SetActive(false);
        }
        if (ramp3.active)
        {
            ramp3.SetActive(false);
        }
   }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        switch (collider.gameObject.name)
        {
            case "Pushable1":
                Debug.Log("Pushable1 has entered goal zone");
                collider.gameObject.SetActive(false);
                ramp1.SetActive(true);
                break;
            case "Pushable2":
                Debug.Log("Pushable2 has entered goal zone");
                collider.gameObject.SetActive(false);
                Pushable2_IsPushed = true;
                break;
            case "Pushable3":
                Debug.Log("Pushable3 has entered goal zone");
                collider.gameObject.SetActive(false);
                Pushable3_IsPushed = true;
                break;
            default:
                break;
        }

        if (Pushable2_IsPushed && Pushable3_IsPushed)
        {
            Debug.Log("Both pushables pushed");
            ramp2.SetActive(true);
            ramp3.SetActive(true);
            GameStateController.IsDogToOwnerTriggerHit = true;
            gameObject.SetActive(false);
        }
    }
}
