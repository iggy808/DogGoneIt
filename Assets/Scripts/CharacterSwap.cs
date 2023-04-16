using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
using Cinemachine;

public class CharacterSwap : MonoBehaviour
{
    public enum Character
    {
        Owner,
        Dog
    }

    GameObject Owner;
    GameObject Dog;
    public Character Current;
    public CinemachineVirtualCamera camera;
    Quaternion cameraStartingRotation;

    // Input references necessary for swap
    StarterAssetsInputs _currentInputController;
    StarterAssetsInputs _ownerInputController;
    StarterAssetsInputs _dogInputController;
    PlayerInput _ownerInput;
    PlayerInput _dogInput;

    // Dog components necessary for swap
    DogController _dogController;
    CharacterController _dogCharacterController;
    ThirdPersonController _dogThirdPerson;

    // Owner components necessary for swap
    CharacterController _ownerCharacterController;
    ThirdPersonController _ownerThirdPerson;

    GameStateController GameStateController;


    void Start()
    {
        // Stash core gameobject references
        Owner = GameObject.FindGameObjectWithTag("Player");
        Dog = GameObject.FindGameObjectWithTag("Dog");
        camera = GameObject.FindGameObjectWithTag("FollowCam").GetComponent<CinemachineVirtualCamera>();
        cameraStartingRotation = camera.transform.rotation;
        // Track current game state
        GameStateController = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameStateController>();
        // Set starting character to owner
        Current = Character.Owner;
        // Collect references to input components necessary for swapping
        // Owner references
        _ownerInput = Owner.GetComponent<PlayerInput>();
        _ownerInputController = Owner.GetComponent<StarterAssetsInputs>();
        _ownerCharacterController = Owner.GetComponent<CharacterController>();
        _ownerThirdPerson = Owner.GetComponent<ThirdPersonController>();
        // Dog references
        _dogInput = Dog.GetComponent<PlayerInput>();
        _dogInputController = Dog.GetComponent<StarterAssetsInputs>();
        _dogCharacterController = Dog.GetComponent<CharacterController>();
        _dogThirdPerson = Dog.GetComponent<ThirdPersonController>();
        _dogController = Dog.GetComponent<DogController>();
        
        // Set owner input controller for starting the game
        _currentInputController = _ownerInputController;
    }

    void Update()
    {
        switch (GameStateController.CurrentGameState)
        {
            case GameState.Reunited:
                if (_currentInputController.swap)
                {
                    if (Current == Character.Owner)
                    {
                        Current = Character.Dog;
                        Swap(Current);
                    }
                    else
                    {
                        Current = Character.Owner;
                        Swap(Current);
                    }
                }
                break;
            
            case GameState.OwnerSolo_Forest:
                if (!GameStateController.IsSwappedFromSoloDogToOwner)
                {
                    Swap(Character.Owner);
                    GameStateController.IsSwappedFromSoloDogToOwner = true;
                }
                break;

            default:
                break;
        }
    }

    public void Swap(Character current)
    {
        if (current == Character.Dog)
        {
            Debug.Log("Swapping to dog");
            // Swap input
            _ownerInput.enabled = false;
            _dogInput.enabled = true;
            // Swap third person controllers controllers
            _ownerThirdPerson.enabled = false;
            _dogThirdPerson.enabled = true;
            // Refocus camera on new player character
            if (GameStateController.CurrentGameState == GameState.DogSolo)
            {
                camera.transform.rotation = new Quaternion(camera.transform.rotation.x,camera.transform.rotation.y * -1,camera.transform.rotation.z,camera.transform.rotation.w);
            }
            camera.LookAt = Dog.transform;
            camera.Follow = Dog.transform;
            // Disable dog follow
            _dogController.enabled = false;
            // Swap character controllers
            _ownerCharacterController.enabled = false;
            _dogCharacterController.enabled = true;
            // Swap input controllers
            _currentInputController.swap = false;
            _currentInputController = _dogInputController;
        }
        else 
        {
            Debug.Log("Swapping to owner");
            // Swap input
            _dogInput.enabled = false;
            _ownerInput.enabled = true;
            // Swap third person controllers controllers
            _dogThirdPerson.enabled = false;
            _ownerThirdPerson.enabled = true;
            if (GameStateController.CurrentGameState == GameState.OwnerSolo_Forest)
            {
                camera.transform.rotation = cameraStartingRotation;
            }
            // Refocus camera on new player character
            camera.LookAt = Owner.transform;
            camera.Follow = Owner.transform;
            // Swap character controllers
            _dogCharacterController.enabled = false;
            _ownerCharacterController.enabled = true;
            // Enable dog follow
            _dogController.enabled = true;
            // Swap input controllers
            _currentInputController.swap = false;
            _currentInputController = _ownerInputController;
        }
    }
}
