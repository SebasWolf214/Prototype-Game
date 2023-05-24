using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    private float puntos;
    private TextMeshProUGUI textMesh;
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        textMesh.text = puntos.ToString("0");
    }
    public void AddPoint(float puntosEnt)
    {
        puntos += puntosEnt;
    }
}
