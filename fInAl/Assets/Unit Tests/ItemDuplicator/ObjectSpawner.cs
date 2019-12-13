using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OVRExtentions
{
    //
    [RequireComponent(typeof(Collider))]
    public class ObjectSpawner: MonoBehaviour
    {
        [Space]
        public OVRGrabbable spawnedGrabable;
        public GameObject monitoredObject;

        private List<GameObject> spawnedGameobjects;

        public void Start() {
            spawnedGameobjects = new List<GameObject>();
            // Ensures that there is a trigger set up on this gameobject
            GetComponent<Collider>().isTrigger = true;
            // Spawn first object
            SpawnNewObject();
        }

        // Spawns a new object if the current object moves out of the trigger space
        private void OnTriggerExit(Collider other) {
            if (other.gameObject == monitoredObject) {
                SpawnNewObject();
            }
        }

        // Creates a new object at the center of the trigger
        private void SpawnNewObject() {
            OVRGrabbable instGrabable = Instantiate(spawnedGrabable, transform.position, transform.rotation);
            monitoredObject = instGrabable.gameObject;
            spawnedGameobjects.Add(instGrabable.gameObject);
        }

        [ContextMenu("Debug-DestroyAllSpawnedObjects")]
        public void DestroyAllSpwanedObjects() {
            foreach (GameObject obj in spawnedGameobjects) {
                if (obj != null) {
                    Destroy(obj);
                }
            }
            spawnedGameobjects = new List<GameObject>();
            SpawnNewObject();
        }
    }
}