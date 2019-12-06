using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForceToObject : MonoBehaviour {

    public int speed;

    public GameObject soup;

    public ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButton(0)) {
            // << use GetMouseButton instead of GetMouseButtonDown
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f)) {
                if (hit.transform.tag == "Player") {
                    Rigidbody rb = hit.transform.gameObject.GetComponent<Rigidbody>();
                    rb.AddForce(new Vector3(0, 10000, 0));
                    rb.AddTorque(40, 40, 40);
                    Debug.Log("You selected the " + hit.transform.name);
                    particles.Play();
                }
            }
        } else if (Input.GetKeyDown(KeyCode.A)) {
            soup.SetActive(!soup.activeSelf);
        }
    }
}
