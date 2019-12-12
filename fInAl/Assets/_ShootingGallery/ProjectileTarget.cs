using UnityEngine;
using System.Collections;
using UnityEngine.Events;

/// <summary>
/// This is a target for use in the shooting gallery
/// If hit by an object with a Projectile component, runs the OnProjectileHit event show in the inspector 
/// </summary>
/// 

public class ProjectileTarget : MonoBehaviour
{
    public UnityEvent OnProjectileHitEvent;

    public void HitReaction(Projectile projectile){

    }

    private void OnCollisionEnter(Collision collision) {
        Projectile projectile = collision.gameObject.GetComponent<Projectile>();
        // A projectile hit this target! React appropriately
        if (projectile != null) {
            // Do general reaction using event in inspector
            Debug.Log("ProjectileHitEvent sent: " + projectile.name);
            if (OnProjectileHitEvent != null) {
                OnProjectileHitEvent.Invoke();
            }
            // Do reaction defined in this class
            HitReaction(projectile);
        }
    }
}
