using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EasyTransition;

public class MenuInicial : MonoBehaviour
{
    public string transitionID;
    public float loadDelay;
    public EasyTransition.TransitionManager transitionManager;
    public void Jugar()
    {
        transitionManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, transitionID, loadDelay);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}
