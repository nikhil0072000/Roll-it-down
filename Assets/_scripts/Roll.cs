using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    public GameObject obj;
    public Material shader;
    
    public float unroll;
    public float roll;
    // Start is called before the first frame update
    void Start()
    {
        
       
        shader.SetFloat("_RollCenterPosX", unroll);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButton(0))
        {
            unroll +=5 * Time.deltaTime;
            
                shader.SetFloat("_RollCenterPosX", unroll);
            if (unroll > 440f)
        
           unroll = 440f;

        }

        //if (unroll > 30)
        //{
        //    unroll = 0;

        //    shader.SetFloat("_RollCenterPosX", unroll / roll);
        //}
    }
}
