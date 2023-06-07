using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachCam : MonoBehaviour
{
    void Start()
    {
        Invoke("AttachTheCam", 0.25f);
    }

    private void AttachTheCam()
    {
        CinemachineConfiner2D confiner = GameObject.FindGameObjectWithTag("NormalCam").GetComponent<CinemachineConfiner2D>();
        confiner.m_BoundingShape2D = GetComponent<Collider2D>();
    }

}
