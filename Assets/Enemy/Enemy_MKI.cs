using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_MKI : MonoBehaviour
{
    public GameObject shot;
    public int HP;
    public int MaxHP = 30;
    public int radius=180;
    private Component stage1;
    private Component stage2;
    private Component stage3;
    public int in_stage;
    private float time;
    private float timer = 0f;
    public bool transition=false;
    public GameManager gm;
    private bool move_left;
    private SpriteRenderer sr;
    private float color_index;


    void Start()
    {
        sr = transform.GetComponent<SpriteRenderer>();
        HP = MaxHP;
        stage1 = transform.Find("Stage1");
        stage2 = transform.Find("Stage2");
        stage3 = transform.Find("Stage3");
        stage2.gameObject.SetActive(false);
        stage3.gameObject.SetActive(false);
        in_stage = 1;

    }

    // Update is called once per frame
    void Update()
    {
        color_index = 1f - (float)HP / (float)MaxHP;
        sr.color = new Color(sr.color.r, color_index, color_index, sr.color.a);
        if (transition)
        {
            timer += 1f * Time.deltaTime;
            if (timer >= 1f)
            {
                transition = false;
                timer = 0f;
            }
            
            transform.position=(in_stage==3)? new Vector3(0, 1f, 0): new Vector3(0, 2f, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else
        {
            switch (in_stage)
            {
                case 1:
                    if (stage1.GetComponent<Stage1_MK1>().stage1_cleared == true)
                    {
                        in_stage = 2;
                        transition = true;
                    }
                    break;
                case 2:
                    stage2.gameObject.SetActive(true);
                    stage1.gameObject.SetActive(false);
                    if (stage2.GetComponent<Stage2_MK1>().stage2_cleared == true)
                    {
                        in_stage = 3;
                        transition = true;
                    }
                    break;
                case 3:
                    stage3.gameObject.SetActive(true);
                    stage2.gameObject.SetActive(false);
                    break;
                default:
                    break;
            }
        }
        

        if (HP <= 0)
        {
            gm.Enemy_killed();
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        switch (in_stage)
        {
            case 1:
                time += Time.fixedDeltaTime;
                transform.rotation = Quaternion.Euler(0, 0, time * 20);
                break;
            case 2:
                break;
            case 3:
                time += Time.fixedDeltaTime;
                transform.rotation = Quaternion.Euler(0, 0, time * 37);
                if (move_left)
                {
                    transform.Translate(Vector2.left*Time.deltaTime);
                    if (transform.position.x <= -1)
                    {
                        move_left = false;
                    }
                }
                else
                {
                    transform.Translate(Vector2.right * Time.deltaTime);
                    
                }
                break;
            default:
                break;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (in_stage != 1 & in_stage!=2 & !transition )
        {
            gm.damage_counter();
            HP -= 1;
        }
            
    }
    
}
