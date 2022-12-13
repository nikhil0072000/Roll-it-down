using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    public Material shader;
    public float unroll;
    public float roll;
    // Start is called before the first frame update
    void Start()
    {
        shader.SetFloat("_RollCenterPosX", unroll / roll);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            unroll +=5;
            
                shader.SetFloat("_RollCenterPosX", unroll / roll);
            if (unroll > 905)
        
           unroll = 905;

        }

        //if (unroll > 30)
        //{
        //    unroll = 0;

        //    shader.SetFloat("_RollCenterPosX", unroll / roll);
        //}
    }
}
