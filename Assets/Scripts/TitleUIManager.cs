using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleUIManager : MonoBehaviour {

    public Animator fadeOutBlackAnimator;
	// Use this for initialization
	void Start () {
        fadeOutBlackAnimator.SetBool("isShow", false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickStart()
    {
        fadeOutBlackAnimator.SetBool("isShow", true);
        StartCoroutine(LoadGameDelay());
    }

    IEnumerator LoadGameDelay()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("InGame");
    }
}
