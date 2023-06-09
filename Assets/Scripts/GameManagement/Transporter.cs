using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transporter : MonoBehaviour
{
    [SerializeField]
    private string sceneName;
    [SerializeField]
    private Vector2 playerPosition;
    [SerializeField]
    private VectorValue playerStorage;
    [SerializeField]
    private bool transportImmediately;

    public bool locked;

    private void Start()
    {
        if(locked)
        {
            GameManager.instance.lockedDoor = this;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(locked)
            {
                //audio of locked door
            } else
            {
                playerStorage.initialValue = playerPosition;
                PlayerController.instance.sceneName = sceneName;
                if (transportImmediately)
                {
                    PlayerController.instance.Transport();
                }
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController.instance.sceneName = "noscene";
        }
    }
}
