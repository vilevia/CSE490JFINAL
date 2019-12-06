using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTrail : MonoBehaviour
{
    [HideInInspector] public List<Vector3> points;
    public float distanceThreshold = 1;
    private float currentDistance;
    private Vector3 prevPosition;

    [Space]
    public float moveSpeed = 5;

    [Space]
    public int listFront = 0;
    public int listMaxSize = 10;

    // Start is called before the first frame update
    void Start()
    {
        points = new List<Vector3>();
        for (int i = 0; i < listMaxSize; i++) {
            points.Add(transform.position + -transform.forward * i);
        }
        prevPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputVec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (inputVec != Vector3.zero) {
            transform.LookAt(transform.position + Vector3.up, inputVec); ;
        }
        transform.position += inputVec * Time.deltaTime * moveSpeed;

        TrackDistance();
    }

    public void TrackDistance() {
        float deltaDist = Vector3.Distance(prevPosition, transform.position);
        prevPosition = transform.position;

        currentDistance += deltaDist;

        if (currentDistance >= distanceThreshold) {
            currentDistance = 0;
            CyclicAdd(points, transform.position);
        }
    }

    public Vector3 GetPointFromStart(float distance) {
        float clampedDist = distance;
        clampedDist = Mathf.Clamp(clampedDist, 0, (points.Count - 1) * distanceThreshold);
        float normalizedDist = distance / distanceThreshold;

        Debug.Log(distance + " ---- " + clampedDist);

        // Clamped downward, return furthest point
        if (clampedDist > distance) {
            return GetCyclicIndex(points, points.Count - 1);
        }
        // Lerp between points
        int pointIndex = Mathf.FloorToInt(normalizedDist);
        Vector3 pointA = GetCyclicIndex(points, pointIndex);
        Vector3 pointB = GetCyclicIndex(points, pointIndex + 1);
        return Vector3.Lerp(pointA, pointB, normalizedDist - Mathf.Floor(normalizedDist));
        
        
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        for (int i = 0; i < points.Count; i++) {
            Vector3 currPoint = GetCyclicIndex(points, i);
            if (i != 0) {
                Vector3 prevPoint = GetCyclicIndex(points, i - 1);
                Gizmos.DrawLine(prevPoint, currPoint);
            }
            Gizmos.DrawSphere(currPoint, 0.1f);
        }
    }
    
    // Functionality for a ring buffer
    private void CyclicAdd(List<Vector3> list, Vector3 elem) {
        int addIndex = (listFront + 1 + list.Count) % list.Count;
        list[addIndex] = elem;
        listFront = addIndex;
    }

    public Vector3 GetCyclicIndex(List<Vector3> list, int index) {
        int trueIndex = (listFront - index + list.Count) % list.Count;
        return list[trueIndex];
    }
}
