using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameObject[] joints;
    public Quaternion[] base_rotations;
    /*
    public float max_angle = 90;
    public float cycle_time = 1;
    public float phase_offset = 0.5f;
    public float current_turn_angle = 0;
    */
    [Space]

    public SnakeTrail snakeTrail;

    // Start is called before the first frame update
    void Start() {
        base_rotations = new Quaternion[joints.Length];
        for (int i = 0; i < joints.Length; i++) {
            GameObject curr_joint = joints[i];
            base_rotations[i] = curr_joint.transform.localRotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float currentDistance = 0;
        for (int i = 0; i < joints.Length; i++) {
            if (i == 0) {
                currentDistance += Vector3.Distance(transform.position, joints[0].transform.position);
            } else {
                currentDistance += Vector3.Distance(joints[i - 1].transform.position, joints[i].transform.position);
            }
            Debug.Log(currentDistance);
            Vector3 targetPos = snakeTrail.GetPointFromStart(currentDistance);
            GameObject curr_joint = joints[i];
            Vector3 lookVector = targetPos - curr_joint.transform.position;



            curr_joint.transform.LookAt(transform.position + Vector3.up * 50, -lookVector);


        }
        /*
        for (int i = 0; i < joints.Length; i++) {
            GameObject curr_joint = joints[i];
            float angle = Mathf.Sin((Time.time / cycle_time * 2 * Mathf.PI) + (phase_offset * i)) * max_angle;
            Quaternion new_rotation = base_rotations[i] * Quaternion.Euler(angle + current_turn_angle, 0, 0);
            curr_joint.transform.localRotation = new_rotation;
        }
        */
    }
}
