using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerView : MonoBehaviour
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
        private playerManager mManager;
        private void Awake() {
            mManager = GetComponent<playerManager>();
        }

        public Vector3 GetCursorPosition() {
            if (mManager.TargetCursor) return mManager.TargetCursor.transform.position;
            else return new Vector3(0f,0f,0f);
        }
        public Vector3Extra getHit() {
            if (mManager.Camera!=null){
                RaycastHit hit;
                if (Physics.Raycast(mManager.Camera.transform.position,mManager.Camera.transform.forward,out hit,mManager.CastMaxDistance,mManager.CastLayerMask )) {
                    //Debug.Log(hit.transform.position);
                    return new Vector3Extra(hit.point, true);
                    }
                else {
                    Vector3 hitNear = mManager.Camera.transform.forward*mManager.CastMaxDistance + mManager.Camera.transform.position;
                    return new Vector3Extra(hitNear, false);
                    }
            }
            else throw new UnityException("Camera is unassigned");
        }
        public Vector3 getCameraPosition() {
            if (mManager.Camera!=null) {
                return mManager.Camera.transform.position;
            }
            else throw new UnityException("Camera is unassigned.");
        }
        public Vector3 getCameraForward() {
            if (mManager.Camera!=null) {
                return mManager.Camera.transform.forward;
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
                switch (mManager.XrCursorState){
                    case XrCursor.SELECTED:
                        mManager.XrCursorState = XrCursor.UNSELECTED;
                        break;
                    case XrCursor.UNSELECTED:
                        mManager.XrCursorState = XrCursor.SELECTED;
                        break;
                }
            }
            switch (mManager.XrCursorState){
                case XrCursor.SELECTED:
                    break;
                case XrCursor.UNSELECTED:
                    mManager.TargetCursor.transform.position = getHit().position;
                    break;
            }
            
            
        }

    }