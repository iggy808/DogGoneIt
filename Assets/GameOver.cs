using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Dog")
        {
            Debug.Log("Game over");
            SceneManager.LoadScene(2);
        }
    }
}
