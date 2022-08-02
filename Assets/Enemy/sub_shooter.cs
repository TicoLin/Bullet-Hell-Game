using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sub_shooter : MonoBehaviour
{
    public int HP;
    public int MaxHP = 20;
    private SpriteRenderer sr;
    private float color_index;
    public bool blood_locked;
    public GameObject gm;

    void Start()
    {
        gm = GameObject.Find("GameManager");
        HP = MaxHP;
        sr = transform.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
        color_index = 1f-(float)HP / (float)MaxHP;
        sr.color = new Color(sr.color.r, color_index, color_index, sr.color.a);
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if (!blood_locked)
        {
            gm.GetComponent<GameManager>().damage_counter();
            HP -= 1;
        }
        
    }
}
