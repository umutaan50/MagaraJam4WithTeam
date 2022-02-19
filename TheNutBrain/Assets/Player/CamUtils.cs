using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamUtils : MonoBehaviour
{
    public float MoveSpeed;
    public Vector3 ofset;
    public Transform Player;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,Player.transform.position + ofset,MoveSpeed * Time.deltaTime);
    }
}
