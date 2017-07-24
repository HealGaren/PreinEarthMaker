using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyDetails : MonoBehaviour {

    public GameObject textPrefab;

    public Text peopleText;
    private int _people;
    public int people
    {
        get
        {
            return _people;
        }
        set
        {
            _people = value;
            peopleText.text = value.ToString();
        }
    }

    public Text environmentText;
    private int _environment;
    public int environment
    {
        set
        {
            _environment = value;
            environmentText.text = value.ToString();
        }
        get
        {
            return _environment;
        }
    }
    public Text coalText;

    private static string GetStepString(int n)
    {
        if (n == 0) return "잠김";
        else return string.Format("{0}단계", n);
    }

    private int _coal;
    public int coal
    {
        set
        {
            _coal = value;
            coalText.text = GetStepString(value);
        }
        get
        {
            return _coal;
        }
    }
    public Text sunText;
    private int _sun;
    public int sun
    {
        get
        {
            return _sun;
        }
        set
        {
            _sun = value;
            sunText.text = GetStepString(value);
        }
    }
    public Text atomicText;
    private int _atomic;
    public int atomic
    {
        get
        {
            return _atomic;
        }
        set
        {
            _atomic = value;
            atomicText.text = GetStepString(value);
        }
    }
 
    // Use this for initialization
    void Start () {
        people = 50;
        environment = 100;
        coal = 0;
        sun = 0;
        atomic = 0;
	}
	 
	// Update is called once per frame
	void Update () {
		
	}

}
