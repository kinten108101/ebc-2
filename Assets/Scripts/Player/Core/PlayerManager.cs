using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EBC.Player.Controller.Core;

namespace EBC.Player.Core {
    public class PlayerManager : MonoBehaviour
    {
        // https://stackoverflow.com/questions/687340/c-sharp-shorthand-property-question

        // for now defaultCameraMode is an initating value, not a variable so no need for high security. Ofc things may change once we consider multiplayer. For example, having only defualtCameraMode assumes that a new player will join with the prefered camera mode in the settings instead of a continuation of their last camera mode. 
        
        [Header("Camerawork")]
        public PlayerViewmode defaultCameraMode;
        // to prevent hierachial issues, implement an additional birdeye camera
        [Header("Editing Mode and Raycasting")]
        

        [SerializeField]private float DefaultZoomSize = 5;
        public float defaultZoom {
            get {
                return DefaultZoomSize;
            }
        }
        
        [Header("XR Mode and Raycasting")]
        
        
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

        // public for now, will be changed later
        public PlayerControllerManager playerControllerManager;
        // wtf is this nomenclature
        public ControllerUiManager controllerUiManager;
        // inventory later
        public Camera playerCam { get; set; }
        void Awake() {
            playerControllerManager = this.transform.Find("controller").GetComponent<PlayerControllerManager>();
            if (!playerControllerManager) throw new UnityException("Failed to initiate playerControllerManager");
            // add xrmanager and  init, or maybe not
            // playercam is empty by default, set a mode so that playerCam can be initiated.
        }
        void Start() {
            CurrentItemID = StartupItemID;
            
            
        }
        void itemUpdate() {

        }
        void Update() {
            
        }
    }
}
