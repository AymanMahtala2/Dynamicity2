using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationItem : MonoBehaviour
{
    private float decayTime = 1.5f;
    private int decaySpeed = 8;

    private int opacity = 255;
    private float startTime;
    private TextMeshProUGUI textObject;
    

    void Start()
    {
        startTime = Time.time;
        textObject = this.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
    }

    void FixedUpdate()
    {
        if (Time.time > startTime + decayTime)
        {
            textObject.faceColor = new Color32(255, 255, 255, (byte)opacity);
            opacity = opacity - decaySpeed;
            if (opacity < 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
