using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothTime = 0.3f;
    public float height = 50f;

    Vector3 vel = Vector3.zero;

    void Update()
    {
        Vector3 pos = new Vector3();

        pos.x = player.position.x;
        pos.y = player.position.y + height;
        pos.z = player.position.z - 15f;

        transform.position = pos;
    }
}
