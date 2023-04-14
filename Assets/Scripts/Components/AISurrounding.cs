using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISurrounding : MonoBehaviour
{
    public bool InVicinity;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            InVicinity = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            InVicinity = false;
        }
    }
}
