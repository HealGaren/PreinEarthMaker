using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameUIManager uiManager;


    public MessageView messageView;
    public Animator fadeInOutAnimator;


	// Use this for initialization
	void Start () {
        fadeInOutAnimator.SetBool("isShow", false);

	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown(KeyCode.K))
        {
            SetDebugNext();

        }
	}

    public void SetDebugNext()
    {
        messageView.ShowText(new string[] { "안녕하세요 가나다라마바사 어그래서\n안녕하세요안녕하세요", "바이바이" }, () => { uiManager.picture.Next(); SetDebugNext(); Debug.Log("z"); });
    }
}
