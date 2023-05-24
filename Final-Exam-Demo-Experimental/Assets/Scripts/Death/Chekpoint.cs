using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chekpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Movement>();
        if (player != null)
        {
            player.SetRespawnPoint(transform.position);
        }
    }

}
