using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickStart()
    {
        SceneManager.LoadScene("InGame");
    }

    public void OnClickContinue()
    {
        SceneManager.LoadScene("InGame");
    }
}
