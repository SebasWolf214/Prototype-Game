using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairAnchor : MonoBehaviour
{
    public Vector2 Offset = Vector2.zero;
    public float LerpSpeed = 20f;
    private Transform[] HairParts;
    private Transform _HairAnchor;
    private void Awake()
    {
        _HairAnchor = GetComponent<Transform>();
        HairParts = GetComponentsInChildren<Transform>();
    }
    private void Update()
    {
        Transform HairFollow = _HairAnchor;
        foreach (Transform HairPart in HairParts)
        {
            //Checa que el cabello anclaje no sea el primero
            if (!HairPart.Equals(_HairAnchor))
            {
                Vector2 TargetPosition = (Vector2)HairFollow.position + Offset;
                Vector2 NewPosition =
                Vector2.Lerp(HairPart.position, TargetPosition, Time.deltaTime * LerpSpeed);

                HairPart.position = NewPosition;
                HairFollow = HairPart;
            }
        }
    }
}
