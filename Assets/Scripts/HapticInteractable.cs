using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticInteractable : MonoBehaviour
{
    [Range(0, 1)]
    public float intensity;
    public float duration;


    // Start is called before the first frame update
    void Start()
    {
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();

        if(interactable == null)
        {
            Debug.LogWarning("인터렉터 상호작용 불가");
        }

        interactable.activated.AddListener(TriggerHaptic);
    }

    public void TriggerHaptic(BaseInteractionEventArgs eventArgs)
    {
        if(eventArgs.interactorObject is XRBaseControllerInteractor controllerInteractor)
        {
            TriggerHaptic(controllerInteractor.xrController);

        }
    }
  
    public void TriggerHaptic(XRBaseController controller)
    {
        if(intensity > 0)
        {
            controller.SendHapticImpulse(intensity, duration);

        }
    }
}
