using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class CollisionDetection : MonoBehaviour
{
    private ThirdPersonController _playerController;
    public AttributesManager playerAtm;
    public AttributesManager enemyAtm;


    private void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonController>();
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.name);
        if (other.tag == "Hitbox" && _playerController.isAttacking) 
        {
            Debug.Log("Collided with Player");
            _playerController.FinishAttack();
            playerAtm.DealDamage(enemyAtm.gameObject);
        }
    }
}
