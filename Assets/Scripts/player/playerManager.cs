using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum XrCursor {
    SELECTED,
    UNSELECTED
}

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



public class playerManager : MonoBehaviour
{
    // https://stackoverflow.com/questions/687340/c-sharp-shorthand-property-question
    
    // stand-in paras
    public Camera Camera {
        get {
            return camera;
        }
    }
    [Header("Camera & Raycasting")][SerializeField]private Camera camera;
    public float CastMaxDistance { 
        get {
            return castMaxDistance;
        } 
    }
    [Tooltip("This should be shared with xrcardboard")][SerializeField]private float castMaxDistance = 1f;
    public LayerMask CastLayerMask { 
        get {
            return castLayerMask;
        }
    }
    [SerializeField]private LayerMask castLayerMask;
    public GameObject TargetHit { 
        get {
            return targetHitObject;
        }
    }
    [SerializeField]private GameObject targetHitObject;
    public GameObject TargetCursor {
        get {
            return targetCursorObject;
        }
    }
    [SerializeField]private GameObject targetCursorObject;
    public XrCursor XrCursorState {
        get {
            return xrCursorState;
        }
        set {
            xrCursorState = value;
        }
    }
    [SerializeField]private XrCursor xrCursorState = XrCursor.UNSELECTED;
    

    [Header("Inventory Management")]
    [SerializeField]private GameObject itemSlot;
    private Item currentWeapon;
    [SerializeField]private int StartupItemID = 0;
    [SerializeField]private int CurrentItemID {
        set {
            currentWeapon = new Item(value);
            itemUpdate();
        }
    }

    private playerView mPlayerView;
    public playerView playerView {
        get {
            return this.GetComponent<playerView>();
        }
    }
  
    void Awake() {
        mPlayerView = this.GetComponent<playerView>();
    }
    void Start() {
        CurrentItemID = StartupItemID;
        
    }
    void itemUpdate() {

    }
    void Update() {
        mPlayerView.updateTarget();
    }
}
