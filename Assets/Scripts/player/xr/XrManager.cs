using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// read this: https://stackoverflow.com/questions/831888/custom-primitives-in-c

public struct Vector3Extra {
    public float x { get; set; }
    public float y { get; set; }
    public float z { get; set; }
    public Vector3 position {
        get {
            return new Vector3(this.x,this.y,this.z);
        }
        set {
            position = value;
        }
    }
    public bool isHit { get; set; }

    public Vector3Extra(float x, float y, float z, bool isHit){
        this.x=x;
        this.y=y;
        this.z=z;
        this.isHit = isHit;
    }
    public Vector3Extra(Vector3 position, bool isHit) {
        this.x = position.x;
        this.y = position.y;
        this.z = position.z;
        this.isHit = isHit;
    }

    // just copy paste
    public static implicit operator string(Vector3Extra p){
        return "("+p.x+","+p.y+","+p.z+","+p.isHit+")";
    }

}

public enum XrCursor {
    SELECTED,
    UNSELECTED
}
public class XrManager : MonoBehaviour
{
    [SerializeField]private Camera XrCamera;
    public Camera xrCam {
        get {
            return XrCamera;
        }
        set {
            XrCamera = value;
        }
    }
    public float castMaxLength {
        get {
            return playerManager.castMaxLength;
        }
    }
    [SerializeField]private LayerMask CastLayerMask;
    public LayerMask castLayer { 
        get {
            return CastLayerMask;
        }
    }
    [SerializeField]private GameObject targetHitObject;
    public GameObject TargetHit { 
        get {
            return targetHitObject;
        }
    }
    [SerializeField]private GameObject targetCursorObject;
    public GameObject TargetCursor {
        get {
            return targetCursorObject;
        }
    }
    [SerializeField]private XrCursor CursorState = XrCursor.UNSELECTED;
    public XrCursor xrCursorState {
        get {
            return CursorState;
        }
        set {
            CursorState = value;
        }
    }
    private PlayerManager playerManager;
    public XrView xrView;
    void Awake() {
        playerManager = GetComponentInParent<PlayerManager>();
        xrView = GetComponent<XrView>();
        xrCursorState = XrCursor.UNSELECTED;
    }
    void Update() {
        // once finished this will be run by xractivity
        xrView.updateTarget();
    }
}

