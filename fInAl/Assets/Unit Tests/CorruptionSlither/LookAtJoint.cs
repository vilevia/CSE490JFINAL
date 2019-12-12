using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtJoint : MonoBehaviour
{

    public GameObject objectToLookAt;
    public Vector3 angleOffset;
    private Quaternion quatOffset;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    public void DoRotation() {


        Vector3 targetDirection = objectToLookAt.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

        quatOffset = Quaternion.Euler(angleOffset);
        targetRotation *= quatOffset;
        transform.rotation = targetRotation;
    }
}
