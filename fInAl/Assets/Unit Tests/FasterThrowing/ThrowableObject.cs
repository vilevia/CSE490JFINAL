using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ThrowableObject : OVRGrabbable
{
    public float throwSpeedMultiplier = 5;
    // Maps from the speed of the hand when this is released to how much of the speed multiplier should be applied (values should range from 0 to 1)
    public AnimationCurve releaseVelocityThresholdCurve;

    public UnityEvent OnGrabBeginEvent;
    public UnityEvent OnGrabEndEvent;

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint) {
        base.GrabBegin(hand, grabPoint);
        if(OnGrabBeginEvent != null) {
            OnGrabBeginEvent.Invoke();
        }

    }

    // Start is called before the first frame update
    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity) {
        base.GrabEnd(linearVelocity, angularVelocity);
        if (OnGrabEndEvent != null) {
            OnGrabEndEvent.Invoke();
        }

        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        float velocityMultiplier = throwSpeedMultiplier * releaseVelocityThresholdCurve.Evaluate(linearVelocity.magnitude);
        velocityMultiplier = Mathf.Max(1, velocityMultiplier);

        rb.velocity *= velocityMultiplier;
        Debug.Log(linearVelocity.magnitude);


    }
}
