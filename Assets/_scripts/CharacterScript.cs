using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterScript : MonoBehaviour
{

    private Animator Charanimator;
    public GameObject CurrentRollingMat;
    private Material crMat;
    public float CharSpeed, RollSpeed;
    private float rolling;
    void Start()
    {
        Charanimator = GetComponent<Animator>();
        crMat = CurrentRollingMat.GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0,0,7.5f), CharSpeed * Time.deltaTime);
        rolling += RollSpeed * Time.deltaTime;
        crMat.SetFloat("_RollCenterPosX", rolling);
      //  Debug.Log(crMat.GetFloat("_RollCenterPosX"));

    }
}
