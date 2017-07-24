using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyDetails : MonoBehaviour {

    public GameObject textPrefab;

    public Text peopleText;
    public int people
    {
        set
        {
            peopleText.text = value.ToString();
        }
    }

    public Text environmentText;
    public int environment
    {
        set
        {
            environmentText.text = value.ToString();
        }
    }
    public Text coalText;

    private static string GetStepString(int n)
    {
        if (n == 0) return "잠김";
        else return string.Format("{0}단계", n);
    }

    public int coal
    {
        set
        {
            coalText.text = GetStepString(value);
        }
    }
    public Text sunText;
    public int sun
    {
        set
        {
            sunText.text = GetStepString(value);
        }
    }
    public Text atomicText;
    public int atomic
    {
        set
        {
            atomicText.text = GetStepString(value);
        }
    }
 
    // Use this for initialization
    void Start () {
		
	}
	 
	// Update is called once per frame
	void Update () {
		
	}

}
