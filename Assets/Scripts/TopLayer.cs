using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopLayer : MonoBehaviour
{

    bool isPicture = true;
    
    public GameObject noiseWrap;
    public Picture picture;
    public EnergyDetails energy;

    Animator noiseWrapAnimator;

    // Use this for initialization
    void Start()
    {
        noiseWrapAnimator = noiseWrap.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    Coroutine myCoroutine = null;

    public void OnClick(){
        noiseWrapAnimator.Play("fade_in_out", -1, 0f);
        isPicture = !isPicture;
        if (myCoroutine != null) StopCoroutine(myCoroutine);
        myCoroutine = StartCoroutine(DelayFunc(isPicture));
    }

    IEnumerator DelayFunc(bool isPicture)
    {
        yield return new WaitForSeconds(0.5f);
        if (isPicture) picture.transform.SetAsLastSibling();
        else picture.transform.SetAsFirstSibling();
    }
}
