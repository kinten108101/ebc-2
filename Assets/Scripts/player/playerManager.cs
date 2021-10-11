using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    [Header("Camera & Raycasting")]
    [SerializeField]private Camera camera;
    [Tooltip("This should be shared with xrcardboardd")][SerializeField]private float castMaxDistance = 999f;
    [SerializeField]private LayerMask castLayerMask;
    [SerializeField]private GameObject hittingTarget;
    private GameObject mHitTarget;
    [SerializeField]private GameObject cursorTarget;
    private GameObject mCursorTarget;
    public Vector3 GetCursorPosition() {
        if (cursorTarget) return cursorTarget.transform.position;
        else return new Vector3(0f,0f,0f);
    }
    [SerializeField]private bool cursorMode = false;

    
    
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
    void init() {
        CurrentItemID = StartupItemID;
    }
    public Vector3 getCameraForward() {
        if (camera!=null) {
            return camera.transform.forward;
        }
        else throw new UnityException("Camera is unassigned.");
    }
    public Vector3 getHitPosition() {
        if (camera!=null){
            RaycastHit hit;
            if (Physics.Raycast(camera.transform.position,camera.transform.forward,out hit,castMaxDistance,castLayerMask )) {
                //Debug.Log(hit.transform.position);
                return hit.point;
                }
            else return new Vector3(0f,0f,0f);
        }
        else throw new UnityException("Camera is unassigned");
    }
    public Vector3 getCameraPosition() {
        if (camera!=null) {
            return camera.transform.position;
        }
        else throw new UnityException("Camera is unassigned.");
    }

    void UpdateTarget() {
        if (Input.GetKeyDown(KeyCode.E)) cursorMode = !cursorMode;
        if (!cursorMode) cursorTarget.transform.position = getHitPosition();
    }
    void itemUpdate() {
        
        
    }
    void Update() {
        UpdateTarget();
    }
}
