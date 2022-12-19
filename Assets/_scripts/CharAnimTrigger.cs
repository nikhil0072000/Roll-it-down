using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharAnimTrigger : MonoBehaviour
{
    private UIscript uis;
    public GameObject ThischaracterHolder, NextCharacterHolder, ThisCharacter, NextCharacter;
    public bool nextroll;
    private void Start()
    {
        uis = FindObjectOfType<UIscript>();

        // NextCharacterHolder.GetComponent<Animator>().speed = 0;

        if (ThisCharacter != null && ThisCharacter.activeInHierarchy == true)
        {

            Debug.Log(gameObject.name);
            ThischaracterHolder.GetComponent<Animator>().speed = 1;
        }
        else
        {
            ThischaracterHolder.GetComponent<Animator>().speed = 0;

        }

    }

    private void Update()
    {
        
    }


    public void gotonextroll()
    {
        StartCoroutine(waitfornextroll());
    }



    IEnumerator waitfornextroll()
    {
        if (nextroll == true)
        {
            ThisCharacter.GetComponent<Animator>().enabled = false;
            ThischaracterHolder.GetComponent<Animator>().enabled = false;

            ThisCharacter.transform.DOMove(NextCharacter.transform.position, 1f);

            if (NextCharacterHolder.transform.rotation.y == 0)
            {
                ThisCharacter.transform.DOLocalRotateQuaternion(Quaternion.Euler(0, 180, 0), 1f);

            }
            else
            {
                ThisCharacter.transform.DOLocalRotateQuaternion(NextCharacter.transform.rotation, 1f);
            }
            yield return new WaitForSeconds(1f);
            ThisCharacter.SetActive(false);
            NextCharacter.SetActive(true);
            NextCharacterHolder.GetComponent<Animator>().speed = 1;
        }
    }

}
