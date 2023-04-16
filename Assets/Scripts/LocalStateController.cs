using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalStateController : MonoBehaviour
{
    GameObject GameManager;
    GameStateController GameStateController;
    CharacterSwap CharacterSwap;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        GameStateController = GameManager.GetComponent<GameStateController>();
        CharacterSwap = GameManager.GetComponent<CharacterSwap>();
    }

    void OnTriggerEnter(Collider collider)
    {
        switch (gameObject.tag)
        {
            case "OwnerToDogTrigger":
                GameStateController.IsOwnerToDogTriggerHit = true;
                GameStateController.CurrentGameState = GameState.DogSolo;
                CharacterSwap.Swap(CharacterSwap.Character.Dog);
                gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
}
