using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    [SerializeField]
    private TriggerInputDetector triggerInputDetector;
    public float maxTime = 3f; // full-grip time
    public float average_input = 0;

    private void Update()
    {
        average_input = (triggerInputDetector.GetLeftGripValue + triggerInputDetector.GetRightGripValue + triggerInputDetector.GetLeftTriggerValue + triggerInputDetector.GetRightTriggerValue) / 4f;

        if (average_input != 0)
        {
            SizeChange(average_input);
        }
    }


    void SizeChange(float triggerinput)
    {
        float newScale = Mathf.Lerp(1f, 4.5f, triggerinput);
        transform.localScale = new Vector3(newScale, newScale, newScale);
        //   objectManager.activeObject.transform.rotation = controller.transform.rotation;

        if (newScale >= 4.4f)
        {
            maxTime -= Time.deltaTime;

            StartCoroutine(SShake());

            if (maxTime <= 0)
            {
                maxTime = 0;
                //   objectManager.destroyObject = true;
                //if (creatrue != null)
                //    creatrue.completed = true;
            }
        }

        else
        {
            maxTime = 3.0f;
        }

    }


    IEnumerator SShake()
    {
        if (gameObject)
        {
            yield return null;
        }


        float t = 1f;
        float shakePower = 0.2f;
        Vector3 origin = gameObject.transform.position;

        while (t > 0f && gameObject)
        {
            t -= 0.05f;
            gameObject.transform.position = origin + (Vector3)Random.insideUnitCircle * shakePower * t;

            yield return null;
        }

        if (gameObject)
        {
            gameObject.transform.position = origin;
        }
    }
}
