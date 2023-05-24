using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource Music;
    private Collider2D me;
    private void Start()
    {
        Music = GetComponent<AudioSource>();
        me = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Musica Inicio
            Music.Play();
            Destroy(me);
        }

    }
}
