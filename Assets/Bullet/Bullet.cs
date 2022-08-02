using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Camera cam;
    private float time;
    public float bulletSpeed=0.005f;
    public float bulletSpacing = 2;
    private bool outOfBounds;
    public int ATK = 1;

    // Start is called before the first frame update
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, bulletSpeed));
        
        
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy_MKI>().HP -= ATK;
            Destroy(gameObject);
        }
    }
}
