using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EBC.Player.Controller.Core;

namespace EBC.Player.Controller.ModeXR {
    public class XrInteraction : MonoBehaviour
    {
        private XrManager xrManager;
        private Vector3 lastVector;
        void Awake() {
            xrManager = this.GetComponent<XrManager>();
        }
        private Rigidbody rbSelected;
        void FixedUpdate() {
            if (Input.GetKeyDown(KeyCode.J)) {
                rbSelected = xrManager.xrView.getHitRb();
                lastVector = xrManager.xrCam.transform.position - rbSelected.transform.position;
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
}