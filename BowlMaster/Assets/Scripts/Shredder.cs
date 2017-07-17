using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

    private void OnTriggerExit(Collider other) {
        GameObject thingLeft = other.gameObject;
        if (thingLeft.GetComponent<Pin>()) {
            Destroy(thingLeft);
        }
    }
}
