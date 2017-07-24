using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectBox : MonoBehaviour {

    public Text leftText, rightText;
    Action leftClick, rightClick;

    [HideInInspector]
    public Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetText(string left, string right)
    {
        leftText.text = left;
        rightText.text = right;
    }

    public void setOnLeftClickOnce(Action action)
    {
        this.leftClick = action;
    }

    public void setOnRightClickOnce(Action action)
    {
        this.rightClick = action;
    }

    public void LeftOnClick()
    {
        var func = this.leftClick;
        leftClick = null;
        if(func != null) func();

    }

    public void RightOnClick()
    {
        var func = this.rightClick;
        rightClick = null;
        if(func != null) func();
    }
}
