using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_bar_sub_shooter : MonoBehaviour
{
    private float MaxHP;
    private float HP;
    public GameObject obj;
    private bool blood_lock;

    // Start is called before the first frame update
    void Start()
    {
        if (obj.GetComponent<sub_shooter>().blood_locked)
        {
            gameObject.SetActive(false);
        }
        MaxHP = obj.GetComponent<sub_shooter>().MaxHP;
        HP = obj.GetComponent<sub_shooter>().HP;
    }

    // Update is called once per frame
    void Update()
    {
        HP = obj.GetComponent<sub_shooter>().HP;
        transform.localScale = new Vector3((HP / MaxHP) * 0.16f, 0.02f, 0.3333333f);
    }
}
