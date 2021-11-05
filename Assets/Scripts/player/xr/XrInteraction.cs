using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XrInteraction : MonoBehaviour
{
    private PlayerManager playerManager;
    private Vector3 lastVector;
    void Awake() {
        playerManager = this.GetComponent<PlayerManager>();
    }
    private Rigidbody rbSelected;
    void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.J)) {
            rbSelected = playerManager.xrManager.xrView.getHitRb();
            lastVector = playerManager.xrManager.xrCam.transform.position - rbSelected.transform.position;
        }
        dragObject();
        // select the rigidbody
        // calculate last vector, store it as placeholder since the moment J is pressed --> oneoff, toggle

        // calculate camera's rotation
        // rotate vector according to that rotation
        // deduce new position
        
    }
    void dragObject() {
        //Screen.s
    }

}
