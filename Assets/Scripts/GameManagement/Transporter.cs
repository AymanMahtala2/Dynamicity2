using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transporter : MonoBehaviour
{
    [SerializeField]
    private int sceneBuildIndex;
    [SerializeField]
    private Vector2 playerPosition;
    [SerializeField]
    private VectorValue playerStorage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerStorage.initialValue = playerPosition;
            PlayerController.instance.sceneBuildIndex = sceneBuildIndex;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController.instance.sceneBuildIndex = 999;
        }
    }
}
