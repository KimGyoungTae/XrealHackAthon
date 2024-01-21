using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using TMPro;

public class TriggerInputDetector : MonoBehaviour
{


    public float GetLeftTriggerValue;
    public float GetLeftGripValue;
    public float GetRightTriggerValue;
    public float GetRightGripValue;

    private InputData _inputData;
    private float _leftMaxScore = 0f;
    private float _rightMaxScore = 0f;
    private float triggerValue;

    private void Start()
    {
        _inputData = GetComponent<InputData>();
        Debug.Log("Started inputData: " + _inputData);
    }
    // Update is called once per frame
    void Update()
    {
        if (_inputData._leftController.TryGetFeatureValue(CommonUsages.trigger, out float leftTriggerValue))
        {
            //_leftMaxScore = theFloat;
            Debug.Log(leftTriggerValue);
            GetLeftTriggerValue = leftTriggerValue;
        }

        if (_inputData._leftController.TryGetFeatureValue(CommonUsages.grip, out float leftGripValue))
        {
            //_leftMaxScore = theFloat;
            Debug.Log(leftGripValue);
            GetLeftGripValue = leftGripValue;
        }


        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.trigger, out float rightTriggerValue))
        {
            //_leftMaxScore = theFloat;
            Debug.Log(rightTriggerValue);
            GetRightTriggerValue = rightTriggerValue;
        }

        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.grip, out float rightGripValue))
        {
            //_leftMaxScore = theFloat;
            Debug.Log(rightGripValue);
            GetRightGripValue = rightGripValue;
        }



        //triggerValue = ((float)_inputData._leftController.characteristics);
        //Debug.Log("triggerValue is: " + triggerValue);

        //if (_inputData._leftController.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 leftVelocity))
        //{
        //    _leftMaxScore = Mathf.Max(leftVelocity.magnitude, _leftMaxScore);
        //    leftScoreDisplay.text = _leftMaxScore.ToString("F2");
        //}
        //if (_inputData._rightController.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 rightVelocity))
        //{
        //    _rightMaxScore = Mathf.Max(rightVelocity.magnitude, _rightMaxScore);
        //    rightScoreDisplay.text = _rightMaxScore.ToString("F2");
        //}
    }
}
