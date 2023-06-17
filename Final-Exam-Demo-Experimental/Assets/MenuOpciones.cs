using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class MenuOpciones : MonoBehaviour
{
    [SerializeField] private AudioMixer _Mixer;
    public GameObject InicialFirst;
    public void FullScreen(bool PantallaCompleta)
    {
        Screen.fullScreen = PantallaCompleta;
    }
    public void ChangeVolumen(float volumen)
    {
        _Mixer.SetFloat("Volumen Master", volumen);
    }
    public void BackMenu()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(InicialFirst);
    }
}
