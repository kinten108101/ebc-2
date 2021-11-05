using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EditCamDir {
    VR = -1,FREE = 0, TOPDOWN = 1, DOWNTOP = 2, FRONT = 3, BACK = 4, LEFT = 5, RIGHT = 6
    }
public class PlayerMode : MonoBehaviour
{
    
    
    private PlayerManager playerManager;
    private Camera mEditCam;
    // the only way to switch between cameras is to use them in turns.
    private Camera mXrCam;
    private float mEditCamSizeConst;
    private EditCamDir mEditCamDir;
    [SerializeField]private KeyCode input;
    void Awake() {
        playerManager = GetComponent<PlayerManager>();
    }
    void Update() {
        editCamDirCheck();
    }
    void editCamDirCheck(){
        // sending a broadcast message with info of cam orientation
        switch(input) {
            case KeyCode.G:
                mEditCamDir = EditCamDir.VR;
                Debug.Log("G pressed, entering VR Mode");
                // setup
                break;
            case KeyCode.T:
                mEditCamDir = EditCamDir.TOPDOWN;
                Debug.Log("T pressed, entering Edit Mode");
                // setup
                //Vector3 lastPos = Vector3.Scale(playerManager.xrRig.position, new Vector3(1f,0f,1f));
                //Vector3 newPos = new Vector3(lastPos.x,100f,lastPos.y);
                //editCamOrthoSet(mEditCamSizeConst,newPos,new Quaternion(0f,-1f,0f,0f));
                //mXrCam.enabled = false;
                //mEditCam.enabled = true;
                break;
        }
    }
}
