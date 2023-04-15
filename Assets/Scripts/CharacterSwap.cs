using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;

public class CharacterSwap : MonoBehaviour
{

    public Transform character;
    public List<Transform> possibleCharacters;
    public int whichCharacter;

    private StarterAssetsInputs _input;
    private PlayerInput _playerInput;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Character Swap Start");
        if (character == null && possibleCharacters.Count >= 1)
        {
            character = possibleCharacters[0];
            _input = character.GetComponent<StarterAssetsInputs>();
            _playerInput = GetComponent<PlayerInput>();
        }
        Swap();
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.swap)
        {
            Debug.Log("Character Swap script");
            if (whichCharacter  == 0)
            {
                whichCharacter = possibleCharacters.Count - 1;
            }
            else
            {
                whichCharacter -= 1;
            }
            Swap();
        }
        
    }

    public void Swap()
    {
        character = possibleCharacters[whichCharacter];
        character.GetComponent<ThirdPersonController>().enabled = true;
        for (int i = 0; i < possibleCharacters.Count; i++)
        {
            if (possibleCharacters[i] != character)
            {
                possibleCharacters[i].GetComponent<ThirdPersonController>().enabled = false;
            }
        }
    }
}
