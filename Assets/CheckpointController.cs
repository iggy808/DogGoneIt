using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class CheckpointController : MonoBehaviour
{
    Transform Checkpoint1Transform;
    Transform Checkpoint2Transform;

    GameObject Owner;
    ThirdPersonController OwnerController;
    Animator OwnerAnimator;

    GameObject Dog;
    ThirdPersonController DogController;
    //Animator DogAnimator;

    bool IsOwnerRespawning;
    bool IsDogRespawning;
    GameStateController GameStateController;
    // Start is called before the first frame update
    void Start()
    {
        Checkpoint1Transform = GameObject.FindGameObjectWithTag("Checkpoint1").GetComponent<Transform>();
        Checkpoint2Transform = GameObject.FindGameObjectWithTag("Checkpoint2").GetComponent<Transform>();
        Owner = GameObject.FindGameObjectWithTag("Player");
        Dog = GameObject.FindGameObjectWithTag("Dog");
        GameStateController = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameStateController>();
        
        OwnerController = Owner.GetComponent<ThirdPersonController>();
        OwnerAnimator = Owner.GetComponent<Animator>();
        DogController = Dog.GetComponent<ThirdPersonController>();
        IsOwnerRespawning = false;
        IsDogRespawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && !IsOwnerRespawning && (GameStateController.CurrentGameState == GameState.OwnerSolo_Preforest))
        {
            // Reset transform to checkpoint position
            Debug.Log("Player fell into death box");
            OwnerController.enabled = false;
            OwnerAnimator.enabled = false;
            Owner.transform.position = Checkpoint1Transform.position;
            Owner.transform.rotation = Checkpoint1Transform.rotation;
            StartCoroutine(WaitForRespawn(collider.gameObject.tag));
        }
        else if (collider.gameObject.tag == "Dog" && !IsDogRespawning)
        {
            Debug.Log("Dog fell off cliff");
            DogController.enabled = false;
            Dog.transform.position = Checkpoint2Transform.position;
            Dog.transform.rotation = Checkpoint2Transform.rotation;
            StartCoroutine(WaitForRespawn(collider.gameObject.tag));
        }
    }

    IEnumerator WaitForRespawn(string tag)
    {
        if (tag == "Player")
        {
            IsOwnerRespawning = true;
            yield return new WaitForSeconds(0.25f);
            OwnerController.enabled = true;
            OwnerAnimator.enabled = true;
            IsOwnerRespawning = false;
        }
        else
        {
            IsDogRespawning = true;
            yield return new WaitForSeconds(0.25f);
            DogController.enabled = true;
            IsDogRespawning = false;
        }
    }
}
