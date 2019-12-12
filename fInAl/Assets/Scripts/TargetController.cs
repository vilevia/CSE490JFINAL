using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetController : MonoBehaviour
{
    public UnityEvent OnProjectileHitEvent;
    public Animator anim;
    public AudioSource source;

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
    }
}
