using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEffect : MonoBehaviour
{
    public static GhostEffect me;
    public GameObject Ghost;
    public List<GameObject> pool = new List<GameObject>();
    private float timer;
    public float speed;
    public Color _color;

    void Awake()
    {
        me = this;
    }
    public GameObject GetGhosts()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                pool[i].transform.position = transform.position;
                pool[i].transform.localScale = transform.localScale;
                pool[i].GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
                pool[i].GetComponent<Solid>()._color = _color;
                return pool[i];
            }
        }
        GameObject obj = Instantiate(Ghost, transform.position, transform.rotation) as GameObject;
        obj.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
        obj.GetComponent<Solid>()._color = _color;
        pool.Add(obj);
        return obj;
    }
    public void GhostSkill()
    {
        timer += speed * Time.deltaTime;
        if (timer > 0.4)
        {
            GetGhosts();
            timer = 0;
        }
    }
}
