using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;

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

    private StarterAssetsInputs _input;
    private PlayerInput _characterInput;
    private PlayerInput _dogInput;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Character Swap Start");
        current = Character.Owner;
        _input = character.GetComponent<StarterAssetsInputs>();
        _characterInput = character.GetComponent<PlayerInput>();
        _dogInput = dog.GetComponent<PlayerInput>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_input.swap)
        {
            Debug.Log("Character Swap script");
            if (current  == Character.Owner)
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

    public void Swap(Character current)
    {
        if (current == Character.Dog)
        {
            Debug.Log("Swapping to dog");
            _characterInput.enabled = false;
            _dogInput.enabled = true;
        }
        else 
        {
            _dogInput.enabled = false;
            _characterInput.enabled = true;
        }
    }
}
