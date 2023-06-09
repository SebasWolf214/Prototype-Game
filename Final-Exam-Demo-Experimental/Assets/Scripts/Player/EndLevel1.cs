using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyTransition;
public class EndLevel1 : MonoBehaviour
{
    public EasyTransition.TransitionManager transitionManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Movement>();
        if (player != null)
        {
            transitionManager.LoadScene("Level 2", "CircleWipe", 0);
        }
    }
}
