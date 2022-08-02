using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot_MKI : MonoBehaviour
{
    public Quaternion InitAngle;
    public int ATK = 1;
    private float speed = 0.005f;
    

    void Start()
    {
        transform.rotation = InitAngle;
    }

    // Update is called once per frame
    void Update()
    {
        //acc type 2
        transform.Translate(new Vector2(0,speed)); 
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<JoystickPlayerExample>().on_hit == false)
            {
                collision.gameObject.GetComponent<JoystickPlayerExample>().HP -= ATK;
                collision.gameObject.GetComponent<JoystickPlayerExample>().on_hit = true;
            }
            
            Destroy(gameObject);
        }
    }
}
