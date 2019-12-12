using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetController : MonoBehaviour
{
    public UnityEvent OnProjectileHitEvent;
    //public Animator anim;
    //public AudioSource source;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision found");
        Projectile p = collision.gameObject.GetComponent<Projectile>();
        if (p != null)
        {
            if (OnProjectileHitEvent != null)
            {
                Debug.Log("Target hit asf boi");
                OnProjectileHitEvent.Invoke();
            }
        }
    }
}
