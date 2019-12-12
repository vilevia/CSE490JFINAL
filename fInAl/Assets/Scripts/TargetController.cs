using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms;
using Random = System.Random;

public class TargetController : MonoBehaviour
{
    public UnityEvent OnProjectileHitEvent;
    public Animator anim;
    public AudioSource source;

    public float speed;


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision found");
        Projectile p = collision.gameObject.GetComponent<Projectile>();
        if (p != null)
        {
            if (OnProjectileHitEvent != null)
            {
                Debug.Log("Collision Detected: " + collision.gameObject.name);
                OnProjectileHitEvent.Invoke();
            }
            anim.SetInteger("Trigger 0", 1);
            source.Play();
        }

        if (collision.gameObject.tag == "bottom") {
            this.transform.position =
                new Vector3(transform.position.x, transform.position.y + 6, transform.position.z);
        }
    }

    void Update() {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
