using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OVRExtentions
{
    public class GrabableSpawner : OVRGrabbable
    {
        [Space]
        public OVRGrabbable spawnedGrabable;
        public void Start() {
            base.Start();
        }

        public override void GrabBegin(OVRGrabber hand, Collider grabPoint) {
            base.GrabBegin(hand, grabPoint);
            base.GrabEnd(Vector3.zero, Vector3.zero);
            OVRGrabbable instGrabable = Instantiate(spawnedGrabable, transform.position, transform.rotation);
            //Debug.LogWarning("AAAA -" + grabbedRigidbody);
            //instGrabable.GrabBegin(hand, grabPoint);
        }

        public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity) {
            base.GrabEnd(linearVelocity, angularVelocity);
        }

        // Update is called once per frame
        void Update() {

        }
    }
}