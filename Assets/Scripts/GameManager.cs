using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameUIManager uiManager;


    public MessageView messageView;
    public Animator fadeInOutAnimator;

    public TopLayer topLayer;

    public Quest quest;

    public Animator npc;

    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }


    // Use this for initialization
    void Start()
    {
        fadeInOutAnimator.SetBool("isShow", false);
        uiManager.picture.SetDoneCallback(() =>
        {
            topLayer.OnClick();
            fadeInOutAnimator.SetBool("isShow", true);
            StartCoroutine(DelayShowEnd());
        });

        StartCoroutine(SetupQuestDelay());



    }

    IEnumerator DelayShowEnd()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("NormalEnd");
    }

    IEnumerator DelayShowBadEnd()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("BadEnd");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int currentIndex = 0;

    public SelectBox selectBox;

    public void SetupQuest()
    {
        StartCoroutine(SetupQuestCoroutine());
    }


    public IEnumerator SetupQuestCoroutine()
    {
        var q = quest.quests[currentIndex];
        npc.GetComponent<RawImage>().texture = quest.whos[q.who];
        npc.SetBool("isShow", true);
        yield return new WaitForSeconds(1);
        selectBox.setOnLeftClickOnce(() =>
        {
            selectBox.animator.SetBool("isShow", false);
            messageView.ShowText(q.left.afterWords, () =>
            {
                npc.SetBool("isShow", false);
                StartCoroutine(DelayAndShowWords(q.left.resultWords, q.left.result));
            });
        });
        selectBox.setOnRightClickOnce(() =>
        {
            selectBox.animator.SetBool("isShow", false);
            messageView.ShowText(q.right.afterWords, () =>
            {
                npc.SetBool("isShow", false);
                StartCoroutine(DelayAndShowWords(q.right.resultWords, q.right.result));
            });
        });
        selectBox.SetText(q.left.answer, q.right.answer);
        messageView.ShowText(q.words, () => {
            selectBox.animator.SetBool("isShow", true);
        });
    }

    IEnumerator DelayAndShowWords(string[] words, Action action)
    {
        yield return new WaitForSeconds(1);
        messageView.ShowText(words, ()=>
        {
            action();
            StartCoroutine(SetupNextQuestDelay());
        });
    }

    IEnumerator SetupNextQuestDelay()
    {
        yield return new WaitForSeconds(1);
        uiManager.year += 10;
        currentIndex++;


        if (!CheckDie())
        {
            SetupQuest();
            //else Debug.Log("end");
        }
    }

    IEnumerator SetupQuestDelay() {
        yield return new WaitForSeconds(1);
        SetupQuest();
    }



    public bool CheckDie()
    {
        if (topLayer.energy.people <= 0)
        {
            fadeInOutAnimator.SetBool("isShow", true);
            StartCoroutine(DelayShowBadEnd());
        }
        
        return false;
    }
}
