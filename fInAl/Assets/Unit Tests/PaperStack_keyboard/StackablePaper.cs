using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class StackablePaper : MonoBehaviour
{
    StackablePaper above;
    StackablePaper below;
    public Transform aboveSnapPoint;
    public Transform belowSnapPoint;

    public float maxTiltPerSec = 30;
    public float fallTiltAngle = 45;
    public AnimationCurve NormalizedAngleToTiltSpeed;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        float currentTilt = Vector3.Angle(transform.up, Vector3.up);
        float normalizedTilt = currentTilt / fallTiltAngle;
        // Check if the stack should fall apart
        if (normalizedTilt > 1) {
            FallFromStack();
        }
        // Listen for the debug key
        if (Input.GetKeyDown("space") && DEBUG) {
            DebugAddPaper();
        }
        // Tilt the stack
        if (above != null) {
            float tiltAmount = NormalizedAngleToTiltSpeed.Evaluate(normalizedTilt);
            Debug.Log(tiltAmount);
            Vector3 tiltAxis = Vector3.Cross(Vector3.up, transform.up).normalized;
            aboveSnapPoint.Rotate(tiltAxis, tiltAmount * maxTiltPerSec * Time.deltaTime); ;
        }

    }

    public void FallFromStack() {
        if (below != null) {
            below.above = null;
            below = null;
            transform.parent = null;
            rb.isKinematic = false;
        }
    }
    public void AddToStack(StackablePaper paper) {
        if (above == null) {
            above = paper;
            above.below = this;
            above.transform.parent = aboveSnapPoint;
            aboveSnapPoint.rotation = Quaternion.identity;
            transform.localRotation = Quaternion.identity;
            SnapPaperToTop(above);
            rb.isKinematic = true;
            rb.velocity = Random.insideUnitSphere;
        }
    }

    public bool DEBUG;
    public StackablePaper paperPrefab;
    private void DebugAddPaper() {
        if (!DEBUG || paperPrefab == null) {
            return;
        }

        StackablePaper instPaper = Instantiate(paperPrefab);
        AddToStack(instPaper);
        instPaper.DEBUG = true;
        DEBUG = false;
    }

    public void SnapPaperToTop(StackablePaper paper) {
        Vector3 positionOffset = aboveSnapPoint.transform.position - paper.belowSnapPoint.transform.position;
        paper.transform.position += positionOffset;
    }
}
