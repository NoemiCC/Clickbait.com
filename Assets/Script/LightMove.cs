using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMove : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        Vector3 newPosition = new Vector3(player.position.x, 11f, player.position.z);
        transform.position = newPosition;
    }
}
