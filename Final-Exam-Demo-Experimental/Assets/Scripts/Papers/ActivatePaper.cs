using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePaper : MonoBehaviour
{
    public AudioSource _FX;
    private Animator Anime;
    private Collider2D me;
    [SerializeField] private ParticleSystem TouchParticles;
    [SerializeField] private float point = 1;
    [SerializeField] private Puntaje puntaje;
    void Start()
    {
        _FX = GetComponent<AudioSource>();
        Anime = GetComponent<Animator>();
        me = GetComponent<Collider2D>();
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Anime.SetBool("CollectPaper", true);
            Destroy(me);
            Destroy(gameObject, 2.5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Efecto de sonido al tocarlo
            _FX.Play();
            TouchParticles.Play();
            //Suma de puntos
            puntaje.AddPoint(point);

        }

    }
}
