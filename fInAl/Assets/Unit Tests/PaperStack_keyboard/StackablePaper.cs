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


    public float restackDelay = 2; // the amount of time it takes to be stackable after falling off a stack
    public float maxTiltPerSec = 30;
    public float fallTiltAngle = 45;
    public AnimationCurve NormalizedAngleToTiltSpeed;


    private Rigidbody rb;
    private bool canStack = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aboveSnapPoint.localScale = new Vector3(1 / transform.localScale.x, 1 / transform.localScale.y, 1 / transform.localScale.z);
        belowSnapPoint.localScale = new Vector3(1 / transform.localScale.x, 1 / transform.localScale.y, 1 / transform.localScale.z);
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
            StartCoroutine(UnstackableForTime(restackDelay));
            rb.velocity = Random.insideUnitSphere / 2;
        }
    }

    public void AddToStack(StackablePaper paper) {
        if (above == null) {
            above = paper;
            above.below = this;
            above.transform.parent = aboveSnapPoint;
            aboveSnapPoint.rotation = Quaternion.identity;
            paper.transform.localRotation = Quaternion.identity;
            SnapPaperToTop(above);
            paper.rb.isKinematic = true;
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

    private void OnCollisionEnter(Collision other) {
        StackablePaper otherStack = other.gameObject.GetComponent<StackablePaper>();
        if (otherStack != null) {
            if (transform.position.y < otherStack.transform.position.y) {
                AddToStack(otherStack);
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        if(above != null) {
            Gizmos.DrawLine(transform.position, aboveSnapPoint.transform.position);
            Gizmos.DrawSphere(aboveSnapPoint.transform.position, 0.1f);
        }
        Gizmos.color = Color.blue;
        if (below != null) {
            Gizmos.DrawLine(transform.position, belowSnapPoint.transform.position);
            Gizmos.DrawSphere(belowSnapPoint.transform.position, 0.1f);
        }
    }

    private IEnumerator UnstackableForTime(float delay) {
        canStack = false;
        yield return new WaitForSeconds(delay);
        canStack = true;

    }
}
