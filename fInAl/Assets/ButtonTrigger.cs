using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonTrigger : MonoBehaviour
{
    public UnityEvent OnGrabberEnter;

    private void OnTriggerEnter(Collider other) {
        OVRGrabber otherGrabber = other.gameObject.GetComponent<OVRGrabber>();
        if (otherGrabber != null) {
            if (OnGrabberEnter != null) {
                OnGrabberEnter.Invoke();
            }
        }
    }
}
