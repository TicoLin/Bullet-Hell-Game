using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject shot;
    public int attackSpeed=30;
    private int counter = 0;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        counter++;
        if (counter % attackSpeed == 0)
        {
            Instantiate(shot, transform.position, new Quaternion(0, 0, 0, 0));
        }
        
    }
}
