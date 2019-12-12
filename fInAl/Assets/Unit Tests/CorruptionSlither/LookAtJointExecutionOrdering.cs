using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtJointExecutionOrdering : MonoBehaviour
{
    public LookAtJoint[] lookAtJointComponents;

    // Start is called before the first frame update
    void Start()
    {
        lookAtJointComponents = GetComponentsInChildren<LookAtJoint>();    
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = lookAtJointComponents.Length - 1; i >= 0; i--) {
        //for(int i = 0; i < lookAtJointComponents.Length; i++) {
            LookAtJoint component = lookAtJointComponents[i];
            if (!component.enabled) { continue; }

            component.DoRotation();
        }
    }
}
