using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressureDetecting : MonoBehaviour
{
    [SerializeField]
    private TriggerInputDetector triggerInputDetector;
    [SerializeField]
    private Material material;
    [SerializeField]
    private Udpnetwork udpnetwork;
    [SerializeField]
    private GameObject liquid;


    [Range(0f, 10f)]
    float fixed_input = 0;

    /*
    [Range(0, 1)]
    public float test_LT;
    [Range(0, 1)]
    public float test_LG;
    [Range(0, 1)]
    public float test_RT;
    [Range(0, 1)]
    public float test_RG;
    */

    [SerializeField] private GameObject particle;

    public float test = 0;
  
    float checkTime = 30f;
    float maxPain = 0f;

    public bool send = false;

    void Update()
    {
        //float sum = (test_LG + test_LT + test_RG + test_RT) / 4f;
        float sum = (triggerInputDetector.GetLeftGripValue + triggerInputDetector.GetRightGripValue + triggerInputDetector.GetLeftTriggerValue + triggerInputDetector.GetRightTriggerValue) / 4f;

        //StartCoroutine(TimeChecker(checkTime));

        //while (checkTime > 0f)
        //{
            checkTime -= Time.deltaTime;
            liquid.transform.localScale = new Vector3(1, sum, 1);
            Color color = new Color(1f, Mathf.Lerp(1f, 0f, sum), 0);
            material.color = color;

            if (sum * 10 > maxPain)
            {
                maxPain = sum * 10;
            }

        //}

        if (send)
        {
            send = false;
            int painstate = (int)(sum*10);
            //checkTime = 10f;
            Debug.Log(painstate);
            udpnetwork.painState = painstate;
            //udpnetwork.painState = (int)test;
            udpnetwork.send = true;
            //gameObject.SetActive(false);
        }

        checkTime = 3f;        
    }

    IEnumerator TimeChecker(float t)
    {
        while (t > 0)
        {
            t -= Time.deltaTime;
            yield return null;
        }

        particle.SetActive(true);
        //ended = true;
    }

}
