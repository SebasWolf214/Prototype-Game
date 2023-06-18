using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EasyTransition;
using UnityEngine.EventSystems;

public class MenuInicial : MonoBehaviour
{
    public string transitionID;
    public float loadDelay;
    public EasyTransition.TransitionManager transitionManager;
    public GameObject OpcionsFirst;
    public GameObject LevelsFirst;

    public void Jugar()
    {
        transitionManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, transitionID, loadDelay);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Levels()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(LevelsFirst);
    }

    public void Opcions()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(OpcionsFirst);
    }
    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}
