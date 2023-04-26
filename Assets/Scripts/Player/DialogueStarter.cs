using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStarter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Dialogue")
        {
            PlayerController.instance.di = collision.GetComponent<DialogueInstigator>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Dialogue")
        {
            PlayerController.instance.di = null;
        }
    }
}
