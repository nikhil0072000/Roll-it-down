using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool Roll1, Roll2, Roll3, Roll4;
    public GameObject Character1, Character2, Character3, Character4;
    public Vector3 char1pos, char2pos, char3pos, char4pos;
    public Quaternion char1rot, char2rot, char3rot, char4rot;
    void Start()
    {
        char1pos = Character1.transform.position;
        char2pos = Character2.transform.position;
        char3pos = Character3.transform.position;
        char4pos = Character4.transform.position;

        char1rot = Character1.transform.rotation;
        char2rot = Character2.transform.rotation;
        char3rot = Character3.transform.rotation;
        char4rot = Character4.transform.rotation;


    }

    void Update()
    {
        
    }

   
}
