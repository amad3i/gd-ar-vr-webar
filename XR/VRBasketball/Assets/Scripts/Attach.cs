using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Attach : MonoBehaviour
{
    private Interactable interactable;
    void Start()
    {
        interactable = GetComponent<Interactable>();
    }
    
    void HandHoverBegin(Hand hand)
    {
       hand.ShowGrabHint(); 
    }
    
    void HandHoverEnd(Hand hand)
    {
        hand.ShowGrabHint(); 
    }
    void HandHoverUpdate(Hand hand)
    {
        GrabTypes grabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabEnding(gameObject);
        
        if (interactable.attachedToHand == null && grabType != GrabTypes.None)
        {
            hand.AttachObject(gameObject, grabType);
            hand.HoverLock(interactable);
            hand.HideGrabHint();
        }
        else if(isGrabEnding)
        {
            hand.DetachObject(gameObject);
            hand.HoverUnlock(interactable);
        }
    }

    void ButtonX()
    {
        
    }
}
