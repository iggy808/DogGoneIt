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
    public bool IsOwnerToDogTriggerHit;
    public bool IsDogToOwnerTriggerHit;
    public bool IsSwappedFromSoloDogToOwner;

    CharacterSwap CharacterSwap;
    DogController DogController;

    MeshRenderer DogsBallMeshRenderer;
    bool DogsBallIsRendered;

    void Start()
    {
        CharacterSwap = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CharacterSwap>();
        DogController = GameObject.FindGameObjectWithTag("Dog").GetComponent<DogController>();
        DogsBallMeshRenderer = GameObject.FindGameObjectWithTag("DogsBall").GetComponent<MeshRenderer>();
        CurrentGameState = GameState.OwnerSolo_Preforest;
        IsOwnerToDogTriggerHit = false;
        IsDogToOwnerTriggerHit = false;
        // Flipped to true in character swap script when finishing solo dog section
        IsSwappedFromSoloDogToOwner = false;
        DogsBallMeshRenderer.enabled = false;
        DogsBallIsRendered = false;
    }

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
        else if (DogController.IsFound)
        {
            CurrentGameState = GameState.Reunited;
            // Prevent continually enabling the DogsBallMeshRenderer
            if (!DogsBallIsRendered)
            {
                DogsBallMeshRenderer.enabled = true;
                DogsBallIsRendered = true;
            }
        }
    }
}
