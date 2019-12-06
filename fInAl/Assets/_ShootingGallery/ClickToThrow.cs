using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Add this component to a camera to allow projectiles to be thrown with on-screen mouse clicks.
/// </summary>
public class ClickToThrow : MonoBehaviour
{
    public float throwSpeed = 5f;
    public float lifetime = 10f;
    public Projectile projectile;

    private Camera cam;

    // Start is called before the first frame update
    void Start() {
        // Sets up the camera automatically
        if (cam == null) {
            cam = GetComponent<Camera>();
            if (cam == null) {
                cam = Camera.main;
            }
        }
    }

    // Update is called once per frame
    void Update() {
        // Throw when left mouse button is clicked
        if (Input.GetMouseButtonDown(0)) {
            LaunchObject();
        }
    }

    void LaunchObject() {
        Ray aimRay = cam.ScreenPointToRay(Input.mousePosition);
        if (projectile == null) {
            Debug.LogWarning("Can't launch object: the projectile prefab is null");
        }
        Projectile instObj = (Projectile)Instantiate(projectile, aimRay.GetPoint(cam.nearClipPlane), cam.transform.rotation);
        instObj.rb.velocity = aimRay.direction * throwSpeed;
        Destroy(instObj.gameObject, lifetime);
    }
}
