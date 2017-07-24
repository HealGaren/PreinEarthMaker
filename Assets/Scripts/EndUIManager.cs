using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndUIManager : MonoBehaviour {

    public Animator fadeInOutImage;
    public bool isToStartScene = false;
	// Use this for initialization
	void Start () {
        fadeInOutImage.SetBool("isShow", false);
        StartCoroutine(DelayNextScene());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator DelayNextScene()
    {
        yield return new WaitForSeconds(3f);
        fadeInOutImage.SetBool("isShow", true);
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(isToStartScene ? "Title" : "InGame");
    }
}
