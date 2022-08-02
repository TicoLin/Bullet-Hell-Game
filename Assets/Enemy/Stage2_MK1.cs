using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_MK1 : MonoBehaviour
{
    // Start is called before the first frame update
    public Component[] sub_shooters;
    public bool stage2_cleared = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (sub_shooters[0] == null & sub_shooters[1]==null)
        {
            stage2_cleared = true;
        }
    }
}
