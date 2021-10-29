using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class item_0000 : MonoBehaviour
{
    [SerializeField]private GameObject mPlayer;
    private playerManager mManager;
    private Vector3 camForward;
    private bool pass = false;
    [SerializeField]private Text mDebugText;
    void Awake() {
         mManager = mPlayer.GetComponent<playerManager>();
    }
    void Update()
    {
        if (pass) {
            Vector3 hitpos = mManager.playerView.getHit().position;
            Vector3 newForward;
            if (hitpos.x == 0f && hitpos.y == 0f && hitpos.y == 0f) {
                hitpos = this.transform.right + this.transform.position;
            }
            newForward = hitpos - this.transform.position;
            //Debug.Log("hitpos: "+hitpos);
            if (mDebugText!=null) mDebugText.text = "hitpos: "+hitpos;
            Quaternion rotation = Quaternion.FromToRotation(this.transform.right,newForward);
            this.transform.rotation = rotation*this.transform.rotation;
        }
    }
    void UpdatePosition() {
        //push the viewmodel away once overturning 90 degrees. This is part of the IK implementation.
    }
    #if UNITY_EDITOR
    void OnDrawGizmos() {
        Handles.color = Color.blue;
        Handles.DrawLine(this.transform.position,this.transform.position+this.transform.forward*1.1f);
    }
    #endif
}
