using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_MK1 : MonoBehaviour
{
    public Component[] sub_shooters;
    public bool stage1_cleared=false;
    
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
        
        if (sub_shooters[0]==null & sub_shooters[1] == null & sub_shooters[2] == null & sub_shooters[3] == null)
        {
            stage1_cleared = true;
        }
    }

    
}
