using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour {

    public Picture picture;

    public Text yearText;

    private int _year;
    public int year
    {
        get
        {
            return _year;
        }
        set
        {
            _year = value;
            yearText.text = value.ToString("D4") + "년";
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
