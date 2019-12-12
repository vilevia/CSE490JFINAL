using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinDetector : MonoBehaviour
{
    public UnityAction<GameObject> CoinDetectedEvent;

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Coin")) {
            Debug.Log("COIN DETECTED!!!");

            if(CoinDetectedEvent != null) {
                CoinDetectedEvent.Invoke(other.gameObject);
            }
        }
    }
}
