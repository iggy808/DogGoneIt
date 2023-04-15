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
    public GameObject character;
    public GameObject dog;
    public Character current;
    public CinemachineVirtualCamera camera;

    private StarterAssetsInputs _input;
    private PlayerInput _characterInput;
    private PlayerInput _dogInput;

    private DogController _dogController;


    // Start is called before the first frame update
    void Start()
    {
        // Set starting character to owner
        current = Character.Owner;
        // Collect references to input components for later swapping
        _input = character.GetComponent<StarterAssetsInputs>();
        _characterInput = character.GetComponent<PlayerInput>();
        _dogInput = dog.GetComponent<PlayerInput>();
        _dogController = dog.GetComponent<DogController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.swap && _dogController.IsFound)
        {
            Debug.Log("Character Swap script");
            if (current == Character.Owner)
            {
                current = Character.Dog;
                _input = dog.GetComponent<StarterAssetsInputs>();
                Swap(current);
            }
            else
            {
                current = Character.Owner;
                _input = character.GetComponent<StarterAssetsInputs>();
                Swap(current);
            }
            _input.swap = false;
        }
    }

    void Swap(Character current)
    {
        if (current == Character.Dog)
        {
            Debug.Log("Swapping to dog");
            // Swap input
            _characterInput.enabled = false;
            _dogInput.enabled = true;
            // Refocus camera on new player character
            camera.LookAt = dog.transform;
            camera.Follow = dog.transform;
        }
        else 
        {
            Debug.Log("Swapping to owner");
            // Swap input
            _dogInput.enabled = false;
            _characterInput.enabled = true;
            // Refocus camera on new player character
            camera.LookAt = character.transform;
            camera.Follow = character.transform;
        }
    }
}
