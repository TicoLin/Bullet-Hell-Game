using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_bar : MonoBehaviour
{
    // Start is called before the first frame update
    public Component[] hearts;
    private int HP;
    public GameObject player;
    void Start()
    {
        if (player != null)
        {
            HP = player.GetComponent<player>().HP;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            HP = player.GetComponent<player>().HP;
        }
        switch (HP)
        {
            case 4:
                hearts[4].gameObject.SetActive(false);
                break;
            case 3:
                hearts[3].gameObject.SetActive(false);
                break;
            case 2:
                hearts[2].gameObject.SetActive(false);
                break;
            case 1:
                hearts[1].gameObject.SetActive(false);
                break;
            case 0:
                hearts[0].gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
}
