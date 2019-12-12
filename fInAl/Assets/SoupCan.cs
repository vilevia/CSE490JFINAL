using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoupCan : MonoBehaviour
{
    public GameObject lights;
    public ParticleSystem[] particles;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Grabbed()
    {
        foreach(ParticleSystem p in particles)
        {
            p.Play();
        }
        lights.GetComponent<Animator>().Play("lights_angry");
        
        
    }

    public void Degrabbed()
    {
        lights.GetComponent<Animator>().Play("lights_idle");
    }
}
