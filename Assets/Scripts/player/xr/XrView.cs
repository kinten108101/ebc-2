using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XrView : MonoBehaviour
    {
        // Setting the cursor
        //private bool hovering;
        //private LayerMask castLayerMask;
        //private GameObject hitTarget;
        //private GameObject cursorTarget;
        //private bool cursorMode;
        //private float castMaxDistance;
    
        // init

        // Start vs Awake: https://gamedevbeginner.com/start-vs-awake-in-unity/
        private XrManager xrManager;
        private void Awake() {
            xrManager = GetComponent<XrManager>();
        }

        public Vector3 GetCursorPosition() {
            if (xrManager.TargetCursor) return xrManager.TargetCursor.transform.position;
            else return new Vector3(0f,0f,0f);
        }
        public Vector3Extra getHit() {
            if (xrManager.xrCam!=null){
                RaycastHit hit;
                if (Physics.Raycast(xrManager.xrCam.transform.position,xrManager.xrCam.transform.forward,out hit,xrManager.castMaxLength,xrManager.castLayer )) {
                    //Debug.Log(hit.transform.position);
                    return new Vector3Extra(hit.point, true);
                    }
                else {
                    Vector3 hitNear = xrManager.xrCam.transform.forward*xrManager.castMaxLength + xrManager.xrCam.transform.position;
                    return new Vector3Extra(hitNear, false);
                    }
            }
            else throw new UnityException("Camera is unassigned");
        }
        public Rigidbody getHitRb() {
            if (xrManager.xrCam!=null){
                RaycastHit hit;
                if (Physics.Raycast(xrManager.xrCam.transform.position,xrManager.xrCam.transform.forward,out hit,xrManager.castMaxLength,xrManager.castLayer )) {
                    //Debug.Log(hit.transform.position);
                    return hit.rigidbody;
                    }
                else {
                    return null;
                    }
            }
            else throw new UnityException("Camera is unassigned");
        }
        public Vector3 getCameraPosition() {
            if (xrManager.xrCam!=null) {
                return xrManager.xrCam.transform.position;
            }
            else throw new UnityException("Camera is unassigned.");
        }
        public Vector3 getCameraForward() {
            if (xrManager.xrCam!=null) {
                return xrManager.xrCam.transform.forward;
            }
            else throw new UnityException("Camera is unassigned.");
        }




        public void updateTarget() {
            
    #if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.E)) 
    #elif UNITY_ANDROID
            if (Input.touchCount==1 && Input.touches[0].phase == TouchPhase.Began)
    #endif
            {
                switch (xrManager.xrCursorState){
                    case XrCursor.SELECTED:
                        xrManager.xrCursorState = XrCursor.UNSELECTED;
                        break;
                    case XrCursor.UNSELECTED:
                        xrManager.xrCursorState = XrCursor.SELECTED;
                        break;
                }
            }
            switch (xrManager.xrCursorState){
                case XrCursor.SELECTED:
                    break;
                case XrCursor.UNSELECTED:
                    xrManager.TargetCursor.transform.position = getHit().position;
                    break;
            }
            
            
        }

    }