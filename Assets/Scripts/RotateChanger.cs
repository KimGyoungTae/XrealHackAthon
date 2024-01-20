using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateChanger : MonoBehaviour
{

    [SerializeField]
    private TriggerInputDetector triggerInputDetector;
    public float average_input = 0;

    public float maxRotationSpeed = 100f; // 최대 회전 속도
    public float rotationSpeedChangeSpeed = 1f; // 회전 속도 변화 속도
    public float triggerStabilityThreshold = 0.1f; // triggerInput이 일정 시간 이상 유지되는지 확인하기 위한 임계값
    private float lastTriggerInput; // 이전 프레임의 triggerInput 값
    private float triggerStabilityTimer; // triggerInput의 안정성을 체크하는 타이머
    private float currentRotationSpeed; // 현재 회전 속도


    public GameObject rotateTaeyop;

    /*
    [Range(0,1)]
    public float test_LT;
    [Range(0, 1)]
    public float test_LG;
    [Range(0, 1)]
    public float test_RT;
    [Range(0, 1)]
    public float test_RG;
    */



    void Update()
    {
        //average_input = (test_LG + test_LT + test_RG + test_RT) / 4f;
        average_input = (triggerInputDetector.GetLeftGripValue + triggerInputDetector.GetRightGripValue + triggerInputDetector.GetLeftTriggerValue + triggerInputDetector.GetRightTriggerValue) / 4f;

        if (average_input != 0)
        {
            RotateTaeyopChanger(average_input);
        }
    }


    void RotateTaeyopChanger(float triggerInput)
    {
        float zRotation = Mathf.Lerp(0, maxRotationSpeed, triggerInput);

        // 각도를 Quaternion으로 변환
        Quaternion rotationQuaternion = Quaternion.Euler(0, 0, zRotation);

        // 현재 회전에 Quaternion을 곱하여 새로운 회전을 얻음
        rotateTaeyop.transform.rotation *= rotationQuaternion;
        /*
        // triggerInput 값이 변하지 않으면 타이머 증가
        if (triggerInput == lastTriggerInput)
        {
            triggerStabilityTimer += Time.deltaTime;

            // 일정 시간 이상 안정하게 유지되면 최대 회전 속도로 설정
            if (triggerStabilityTimer > triggerStabilityThreshold)
            {
                currentRotationSpeed = maxRotationSpeed;
               
            }
        }
        else
        {
            // triggerInput 값이 변하면 타이머 초기화
            triggerStabilityTimer = 0f;
        }

        // 서서히 최대 회전 속도로 변경
        currentRotationSpeed = Mathf.MoveTowards(currentRotationSpeed, maxRotationSpeed, Time.deltaTime * rotationSpeedChangeSpeed);

        

        // 시간에 따라 Z 회전값 증가
        float zRotation = Time.time * currentRotationSpeed;

        // 오브젝트의 회전을 설정
        rotateTaeyop.transform.rotation = Quaternion.Euler(0, 0, zRotation);

        // 현재 triggerInput을 이전 값으로 저장
        lastTriggerInput = triggerInput;
        */
    }
}
