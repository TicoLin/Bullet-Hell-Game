using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public int HP = 25;
    public float speed;
    public FloatingJoystick floatingJoystick;
    public DynamicJoystick dynamicJoystick;
    public Rigidbody2D rb;
    public GameManager gm;
    public bool on_hit=false;
    private float timer = 0.0f;
    private float end_time = 0.0f;


    private void Update()
    {
        if (HP <= 0)
        {
            gm.PlayerIsDead();
            Destroy(gameObject);
        }


        
        if (on_hit == true)
        {
            timer = Time.time;
            if (timer > end_time)
            {
                on_hit = false;
            }
        }
        else
        {
            end_time = Time.time + 2;
        }
    }
    public void FixedUpdate()
    {
        rb.transform.Translate(new Vector2(dynamicJoystick.Horizontal * 0.1f, dynamicJoystick.Vertical*0.1f));
    }


}