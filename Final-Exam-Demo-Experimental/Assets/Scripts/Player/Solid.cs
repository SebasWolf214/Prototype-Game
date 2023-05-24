using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solid : MonoBehaviour
{
    private SpriteRenderer MyRender;
    private Shader MyMaterial;
    public Color _color;
    void Start()
    {
        MyRender = GetComponent<SpriteRenderer>();
        MyMaterial = Shader.Find("GUI/Text Shader");
    }
    void ColorSprite()
    {
        MyRender.material.shader = MyMaterial;
        MyRender.color = _color;
    }
    public void Finish()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        ColorSprite();
    }
}
