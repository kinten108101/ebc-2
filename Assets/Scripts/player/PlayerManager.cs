using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    // https://stackoverflow.com/questions/687340/c-sharp-shorthand-property-question
    
    
    // to prevent hierachial issues, implement an additional birdeye camera
    [Header("Editing Mode and Raycasting")]
    public EditManager editManager;

    [SerializeField]private float DefaultZoomSize = 5;
    public float defaultZoom {
        get {
            return DefaultZoomSize;
        }
    }
    
    [Header("XR Mode and Raycasting")]
    public XrManager xrManager;
    
    [Tooltip("This should be shared with xrcardboard")][SerializeField]private float CastMaxDistance = 1f;
    public float castMaxLength { 
        get {
            return CastMaxDistance;
        } 
    }
    
    

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


  
    void Awake() {
        
    }
    void Start() {
        CurrentItemID = StartupItemID;
        
    }
    void itemUpdate() {

    }
    void Update() {
        
    }
}
