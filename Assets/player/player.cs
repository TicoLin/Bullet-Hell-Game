using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    public int HP = 25;
    public float speed;
    public DynamicJoystick dynamicJoystick;
    public Rigidbody2D rb;
    public GameManager gm;
    public bool on_hit = false;
    private float hit_time = 2f;
    private float timer = 0f;
    public Animator ani;
    public AudioSource Get_hit_sound;

    private void Start()
    {
        if (dynamicJoystick == null)
        {
            
        }
    }

    private void Update()
    {
        if (HP <= 0)
        {
            gm.PlayerIsDead();
            Destroy(gameObject);
        }
        if (on_hit)
        {
            timer += 1f * Time.deltaTime;
            if (timer >= hit_time)
            {
                on_hit = false;
                timer = 0f;
                ani.SetBool("on_hit", false);
                
            }
        }
        

    }
    public void FixedUpdate()
    {
        rb.transform.Translate(new Vector2(dynamicJoystick.Horizontal * 0.1f, dynamicJoystick.Vertical * 0.1f));
    }

    private void OnParticleCollision(GameObject other)
    {
        
        if (!on_hit)
        {
            Debug.Log("hit!");
            HP -= 1;
            on_hit = true;
            Get_hit_sound.Play();
            ani.SetBool("on_hit", true);
        }
        
    }
}
