using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class CharAnimTrigger : MonoBehaviour
{
    private UIscript uis;
    public GameObject ThischaracterHolder, NextCharacterHolder, BackCharacterHolder, ThisCharacter, NextCharacter, BackCharacter, ThisRoll, PlayerShovel;
    public bool nextroll, roll1, roll2,roll3,roll4, LastCharacter;
    public Vector3 AnimEndPos;
    private Vector3 RollScale;
    private Vector3 ThisInitialposition, ThisInitialRotation;
    // public string rollbool;
    private GameManager gm;
    private void Start()
    {
        RollScale = ThisRoll.transform.localScale;
        ThisInitialposition = ThisCharacter.transform.position;
        // Debug.Log(ThisCharacter.transform.parent.name + "=" + ThisInitialTransfrom.localPosition);
       // Debug.Log(ThisCharacter.transform.parent.name + "=" + ThisInitialposition);

        uis = FindObjectOfType<UIscript>();
        gm = FindObjectOfType<GameManager>();
        // NextCharacterHolder.GetComponent<Animator>().speed = 0;
        StartRolling();
        

    }

    private void Update()
    {
        
    }

    public void StartRolling()
    {
        if (ThisCharacter != null && ThisCharacter.activeInHierarchy == true)
        {

            //Debug.Log(gameObject.name);
            ThischaracterHolder.GetComponent<Animator>().speed = 1;
            ThischaracterHolder.GetComponent<Animator>().Play("RollingAnim");
        }
        else
        {
            ThischaracterHolder.GetComponent<Animator>().speed = 0;

        }
    }

    public void gotonextroll()
    {
        StartCoroutine(waitfornextroll());
    }


    IEnumerator waitfornextroll()
    {
        ThisRoll.transform.DOScale(new Vector3(ThisRoll.transform.localScale.x, 0, 0), 1f); 
        if (nextroll == true)
        {
           // ThisCharacter.GetComponent<Animator>().enabled = false;
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
            NextCharacterHolder.GetComponent<Animator>().Play("RollingAnim");


        }

        if (ThisCharacter.activeInHierarchy == true)
        {
            // Debug.Log("vidtory");
           // PlayerShovel.transform.DOScale(new Vector3(0, 0, 0), 0.5f);
            ThisCharacter.GetComponent<Animator>().Play("Victory Idle");
        }
        yield return new WaitForSeconds(1f);

        //GameManager gm = FindObjectOfType<GameManager>();
        //gm.
        //gm.ro
        if(roll1 == true)
        {
            gm.Roll1 = true;
        }else if(roll2 == true)
        {
            gm.Roll2 = true;
        }
        else if (roll3 == true)
        {
            gm.Roll3 = true;
        }
        else if (roll4 == true)
        {
            gm.Roll4 = true;
        }


        if (gm.Roll1 == true && gm.Roll2 == true && gm.Roll3 == true && gm.Roll4 == true)
        {
            Debug.Log("LayerComplete");
            CharAnimTrigger[] chars = GameObject.FindObjectsOfType<CharAnimTrigger>();
            foreach (CharAnimTrigger item in chars)
            {
                item.gotonextlayerfunc();
            }
           //StartCoroutine(GotoNextLayer());
        }
    }




    public void gotonextlayerfunc()
    {
        //  StartCoroutine(GotoNextLayer());
        StartRollingBack();
    }

    IEnumerator GotoNextLayer()
    {
        Debug.Log("here");
        //  Debug.Log(ThisCharacter.transform.parent.name + "=" + ThisInitialTransfrom.localPosition);
        if (LastCharacter == true)
        {

         
        }
        else
        {
            ThischaracterHolder.GetComponent<Animator>().Play("New State");
            ThischaracterHolder.GetComponent<Animator>().enabled = false;
            //Debug.Log(ThisCharacter.transform.parent.name + "=" + ThisInitialposition);
            ThisCharacter.transform.DOMove(ThisInitialposition, 2f);
            ThisCharacter.transform.DORotateQuaternion(Quaternion.Euler(ThisInitialRotation), 2f);
        }
        yield return new WaitForSeconds(2f);
       // ThischaracterHolder.GetComponent<Animator>().enabled = true;
       // ThischaracterHolder.GetComponent<Animator>().Play("RollingAnim");
       // ThischaracterHolder.GetComponent<Animator>().speed = 0;
      //  StartRolling();
    }




    public void StartRollingBack()
    {
        if (ThisCharacter != null && ThisCharacter.activeInHierarchy == true)
        {

            //Debug.Log(gameObject.name);
            ThisCharacter.GetComponent<Animator>().Play("Crouched Run");
            ThischaracterHolder.GetComponent<Animator>().speed = 1;
            ThischaracterHolder.GetComponent<Animator>().Play("RollingAnimReverse");
        }
        else
        {
            ThischaracterHolder.GetComponent<Animator>().speed = 0;

        }
    }


    public void gotobackroll()
    {
        StartCoroutine(waitforbackroll());
    }
    IEnumerator waitforbackroll()
    {
      //  PlayerShovel.transform.localScale = new Vector3(1, 1, 1);
        ThisRoll.transform.DOScale(new Vector3(ThisRoll.transform.localScale.x, 0, 0), 1f);
        if ( BackCharacterHolder != null && BackCharacterHolder.GetComponent<CharAnimTrigger>().nextroll == true)
        {
            // ThisCharacter.GetComponent<Animator>().enabled = false;
            ThischaracterHolder.GetComponent<Animator>().enabled = false;
            //BackCharacterHolder.GetComponent<Animator>().enabled = true;
            //Debug.Log("BCH = " + BackCharacterHolder.GetComponent<Animator>().enabled);
            BackCharacter.transform.localPosition = new Vector3(0.9f, 0, 7.5f);
            ThisCharacter.transform.DOMove(BackCharacter.transform.position, 1f);

            if (BackCharacterHolder.transform.rotation.y == 0)
            {
                ThisCharacter.transform.DOLocalRotateQuaternion(Quaternion.Euler(0, 0, 0), 1f);

            }
            else
            {
                ThisCharacter.transform.DOLocalRotateQuaternion(BackCharacter.transform.rotation, 1f);
            }
            yield return new WaitForSeconds(1f);
            ThisCharacter.SetActive(false);
            BackCharacter.SetActive(true);
            BackCharacterHolder.GetComponent<Animator>().enabled = true;
            BackCharacterHolder.GetComponent<Animator>().speed = 1;
            BackCharacterHolder.GetComponent<Animator>().Play("RollingAnimReverse");


        }

        if (ThisCharacter.activeInHierarchy == true)
        {
            // Debug.Log("vidtory");
           // PlayerShovel.transform.DOScale(new Vector3(1, 1, 1), 0.5f);
           // ThisCharacter.GetComponent<Animator>().Play("Victory Idle");
        }
        yield return new WaitForSeconds(1f);

        //GameManager gm = FindObjectOfType<GameManager>();
        //gm.
        //gm.ro
        if (roll1 == true)
        {
            gm.Roll1 = false;
        }
        else if (roll2 == true)
        {
            gm.Roll2 = false;
        }
        else if (roll3 == true)
        {
            gm.Roll3 = false;
        }
        else if (roll4 == true)
        {
            gm.Roll4 = false;
        }


        if (gm.Roll1 == false && gm.Roll2 == false && gm.Roll3 == false && gm.Roll4 == false)
        {
            Debug.Log("LayerReached");
            //CharAnimTrigger[] chars = GameObject.FindObjectsOfType<CharAnimTrigger>();
            //foreach (CharAnimTrigger item in chars)
            //{
            //    item.gotonextlayerfunc();
            //}
            //StartCoroutine(GotoNextLayer());
        }
    }











    public void FinalCharMovement()
    {
        if(LastCharacter == true)
        {

            //int charnumber = GameObject.FindGameObjectsWithTag("Character").Length;
            //if(charnumber == 3)
            //{
            //    ThischaracterHolder.GetComponent<Animator>().Play("New State");
            //    ThischaracterHolder.GetComponent<Animator>().enabled = false;
            //    //Debug.Log(ThisCharacter.transform.parent.name + "=" + ThisInitialposition);
            //    ThisCharacter.transform.DOMove(gm.char3pos, 2f);
            //    ThisCharacter.transform.DORotateQuaternion(gm.char3rot, 2f);
            //}
            //if(charnumber == 2)
            //{
            //    ThischaracterHolder.GetComponent<Animator>().Play("New State");
            //    ThischaracterHolder.GetComponent<Animator>().enabled = false;
            //    //Debug.Log(ThisCharacter.transform.parent.name + "=" + ThisInitialposition);
            //    ThisCharacter.transform.DOMove(gm.char2pos, 2f);
            //    ThisCharacter.transform.DORotateQuaternion(gm.char2rot, 2f);
            //}
            //if(charnumber == 1)
            //{
            //    ThischaracterHolder.GetComponent<Animator>().Play("New State");
            //    ThischaracterHolder.GetComponent<Animator>().enabled = false;
            //    //Debug.Log(ThisCharacter.transform.parent.name + "=" + ThisInitialposition);
            //    ThisCharacter.transform.DOMove(gm.char1pos, 2f);
            //    ThisCharacter.transform.DORotateQuaternion(gm.char1rot, 2f);
            //}
            //if (charnumber == 4)
            //{
            //    ThischaracterHolder.GetComponent<Animator>().Play("New State");
            //    ThischaracterHolder.GetComponent<Animator>().enabled = false;
            //    //Debug.Log(ThisCharacter.transform.parent.name + "=" + ThisInitialposition);
            //    ThisCharacter.transform.DOMove(gm.char4pos, 2f);
            //    ThisCharacter.transform.DORotateQuaternion(gm.char4rot, 2f);
            //}


           // if(gm.character)




            //if(gm.Character1.activeInHierarchy == true && gm.Character2.activeInHierarchy == false && gm.Character3.activeInHierarchy == false)
            //{
            //    ThischaracterHolder.GetComponent<Animator>().Play("New State");
            //    ThischaracterHolder.GetComponent<Animator>().enabled = false;
            //    //Debug.Log(ThisCharacter.transform.parent.name + "=" + ThisInitialposition);
            //    ThisCharacter.transform.DOMove(gm.Character1.transform.position, 2f);
            //    ThisCharacter.transform.DORotateQuaternion(gm.Character1.transform.rotation, 2f);
            //}
            //if (gm.Character1.activeInHierarchy == true && gm.Character2.activeInHierarchy == true && gm.Character3.activeInHierarchy == false )
            //{
            //    ThischaracterHolder.GetComponent<Animator>().Play("New State");
            //    ThischaracterHolder.GetComponent<Animator>().enabled = false;
            //    //Debug.Log(ThisCharacter.transform.parent.name + "=" + ThisInitialposition);
            //    ThisCharacter.transform.DOMove(gm.Character2.transform.position, 2f);
            //    ThisCharacter.transform.DORotateQuaternion(gm.Character2.transform.rotation, 2f);
            //}
            //if (gm.Character1.activeInHierarchy == true && gm.Character3.activeInHierarchy == true )
            //{
            //    ThischaracterHolder.GetComponent<Animator>().Play("New State");
            //    ThischaracterHolder.GetComponent<Animator>().enabled = false;
            //    //Debug.Log(ThisCharacter.transform.parent.name + "=" + ThisInitialposition);
            //    ThisCharacter.transform.DOMove(gm.Character3.transform.position, 2f);
            //    ThisCharacter.transform.DORotateQuaternion(gm.Character3.transform.rotation, 2f);
            //}


            //yield return new WaitForSeconds(2f);
        }
    }
}
