using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    OwnerSolo_Preforest,
    DogSolo,
    OwnerSolo_Forest,
    Reunited
}


public class GameStateController : MonoBehaviour
{
    public GameState CurrentGameState;
    CharacterSwap CharacterSwap;

    public bool IsOwnerToDogTriggerHit;
    public bool IsDogToOwnerTriggerHit;
    public bool IsSwappedFromSoloDogToOwner;

    // Start is called before the first frame update
    void Start()
    {
        CharacterSwap = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CharacterSwap>();
        CurrentGameState = GameState.OwnerSolo_Preforest;
        IsOwnerToDogTriggerHit = false;
        IsDogToOwnerTriggerHit = false;
        IsSwappedFromSoloDogToOwner = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOwnerToDogTriggerHit && !(IsDogToOwnerTriggerHit))
        {
            CurrentGameState = GameState.DogSolo;
        }
        else if (IsDogToOwnerTriggerHit && !IsSwappedFromSoloDogToOwner)
        {
            CurrentGameState = GameState.OwnerSolo_Forest;
        }
    }
}
