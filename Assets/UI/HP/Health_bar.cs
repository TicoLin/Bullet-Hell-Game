using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_bar : MonoBehaviour
{
    private float MaxHP;
    private float HP;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        MaxHP = obj.GetComponent<Enemy_MKI>().MaxHP;
        HP =obj.GetComponent<Enemy_MKI>().HP;
    }

    // Update is called once per frame
    void Update()
    {
        HP = obj.GetComponent<Enemy_MKI>().HP;
        transform.localScale = new Vector3(HP / MaxHP, 1, 1);
    }
}
