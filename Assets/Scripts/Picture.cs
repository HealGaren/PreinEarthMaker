using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picture : MonoBehaviour
{
    public Animator[] bgArray;
    public Animator[] bg01Array;
    public Animator[] bg2Array;
    public Animator[] bg3Array;

    public Animator[] windowArray;


    private Animator[][] innerArray;

    private int currentBG = 0;
    private int nextIndex = 0;

    // Use this for initialization
    void Start()
    {
        innerArray = new Animator[][] { bg01Array, bg2Array, bg3Array };
        bgArray[0].gameObject.SetActive(true);
        bgArray[1].gameObject.SetActive(false);
        bgArray[2].gameObject.SetActive(false);

    }

    Action callback;

    public void SetDoneCallback(Action callback)
    {
        this.callback = callback;
    }

    public void Next()
    {
        if (innerArray[currentBG].Length == nextIndex)
        {
            if (currentBG + 1 == bgArray.Length)
            {
                if (callback != null)
                {
                    var cb = callback;
                    callback = null;
                    cb();
                }
                return;
            }
            bgArray[currentBG + 1].gameObject.SetActive(true);
            bgArray[currentBG].SetBool("isShow", false);
            windowArray[currentBG].SetBool("isShow", false);

            currentBG++;
            nextIndex = 0;
        }
        else
        {
            innerArray[currentBG][nextIndex].SetBool("isShow", true);
            nextIndex++;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
