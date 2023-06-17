using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject _MenuPausa;
    private bool GamePausa = false;
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (GamePausa)
            {
                Continuo();
            }
            else
            {
                Pausa();
            }

        }
    }
    public void Pausa()
    {
        GamePausa = true;
        Time.timeScale = 0f;
        _MenuPausa.SetActive(true);
    }
    public void Continuo()
    {
        GamePausa = false;
        Time.timeScale = 1f;
        _MenuPausa.SetActive(false);
    }

}
