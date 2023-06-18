using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using EasyTransition;
public class MenuNiveles : MonoBehaviour
{
    public GameObject InicialFirst;
    public EasyTransition.TransitionManager transitionManager;
    public void Level01()
    {
        transitionManager.LoadScene("Level 1", "CircleWipe", 0);
    }
    public void Level02()
    {
        transitionManager.LoadScene("Level 2", "CircleWipe", 0);
    }
    public void Level03()
    {
        transitionManager.LoadScene("Level 3", "CircleWipe", 0);
    }
    public void BackMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(InicialFirst);
    }
}
