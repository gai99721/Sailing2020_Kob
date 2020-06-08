using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Text;
using UnityEngine;

public class HintPop : MonoBehaviour
{
    
    public float HintEnableTime
    {
        get;
        private set;
    }

    public bool IsHint
    {
        get;
        private set;
    }

    [SerializeField]
    private GameObject HintUI;

    private void Awake()
    {

        HintEnableTime = 23.7f;
        IsHint = false;

        HintUI.gameObject.SetActive(false);

    }

    private void FixedUpdate()
    {

        HintEnableTime -= Time.deltaTime;
        IsHint = FindObjectOfType<Sailing.ShipObject>().HintEnable(IsHint);
        //Debug.Log(IsHint);

        if(HintEnableTime <= 0 && IsHint)
        {
            //Debug.Log("HintEnable!!");
            HintUI.gameObject.SetActive(true);
        }
        else if(HintEnableTime <= 0 && !IsHint)
        {
            HintEnableTime = 10.0f;
        }
        else
        {
            HintUI.gameObject.SetActive(false);
        }

        /*if(FindObjectOfType<Sailing.ShipObject>().IsGoal == true)
        {
            IsHint = false;
        }*/

    }



}
