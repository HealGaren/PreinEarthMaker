using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public MessageView messageView;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown(KeyCode.K))
        {
            messageView.ShowText(new string[] { "안녕하세요 가나다라마바사 어그래서\n안녕하세요안녕하세요", "바이바이" }, () => { Debug.Log("ㅁㄴㅇㄹ"); });
        }
	}
}
