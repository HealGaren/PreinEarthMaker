using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageView : MonoBehaviour {

    public Text messageText;
    public RawImage messageArrow;
    Animator arrowAnimator;
    List<string> targetStr = new List<string>();
    int currentLength = 0;
    int currentIndex = 0;

    float currentTime = 0;
    public float textTime = 0.05f;
    bool _textFinish = true;
    bool textFinish
    {
        get
        {
            return _textFinish;
        }
        set
        {
            _textFinish = value;
            arrowAnimator.SetBool("isBlink", value);
        }
    }
    Action callback = null;

	// Use this for initialization
	void Start () {
        arrowAnimator = messageArrow.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!textFinish)
        {
            currentTime += Time.deltaTime;
            if (currentTime > textTime)
            {
                currentTime -= textTime;
                NextStr();
            }
        }
	}
    public void ShowText(IEnumerable<string> str, Action callback = null)
    {
        if (callback != null) this.callback = callback;
        targetStr.Clear();
        targetStr.AddRange(str);
        currentLength = -1;
        currentIndex = 0;
        textFinish = false;
        NextStr();
    }

    public void ShowText(string str)
    {
        targetStr.Clear();
        targetStr.Add(str);
        currentLength = -1;
        currentIndex = 0;
        textFinish = false;
        NextStr();

    }

    void NextStr()
    {
        currentLength++;
        if (currentLength > targetStr[currentIndex].Length)
            textFinish = true;
        else messageText.text = targetStr[currentIndex].Substring(0, currentLength);
    }

    public void ClickMessage()
    {
        if (textFinish) NextMessage();
        else SkipMessage();
    }

    public void NextMessage()
    {
        currentIndex++;
        if (currentIndex >= targetStr.Count)
        {
            if (callback != null)
            {
                var cb = callback;
                callback = null;
                cb();
            }
        }
        else
        {
            currentLength = 0;
            textFinish = false;
            messageText.text = "";
        }

    }

    public void SkipMessage()
    {
        currentLength = targetStr[currentIndex].Length + 1;
        textFinish = true;
        messageText.text = targetStr[currentIndex];
    }

}
