using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EBC.Player.Core;


namespace EBC.Player.Controller.Core {

    public class PlayerControllerManager : MonoBehaviour
    {
        
        public PlayerViewmode currentMode { get; set; }
        public PlayerViewmode lastMode { get; set; }
        private PlayerManager playerManager;

        // are there any other way to refer to children? Instancing is a nightmare.
        public XrManager xrManager;
        public EditManager editManager;
        public ControllerUiManager uiManager;

        public PlayerSwitchMode playerSwitchMode;
        
        public PlayerViewmode[] cameraModeStack = new PlayerViewmode[2];
        public void AddToModeStack(PlayerViewmode newmode) {
            cameraModeStack[0] = cameraModeStack[1];
            cameraModeStack[1] = newmode;
        }
        [Tooltip("Read Only")][SerializeField]private KeyCode CurrentInput;
        [Header("Keyboard Settings")]
        [SerializeField]private KeyCode TopdownCameraKey;
        public KeyCode inputCamTop {
            get {
                return TopdownCameraKey;
            }
        }
        [SerializeField]private KeyCode BottomupCameraKey;
        public KeyCode inputCamBottom {
            get {
                return BottomupCameraKey;
            }
        }
        [SerializeField]private KeyCode FreeCameraKey;
        public KeyCode inputCamNone {
            get {
                return FreeCameraKey;
            }
        }
        [SerializeField]private KeyCode VrCameraKey;
        public KeyCode inputCamVr {
            get {
                return VrCameraKey;
            }
        }

        void Awake() {
            playerManager = GetComponentInParent<PlayerManager>();
            playerSwitchMode = GetComponent<PlayerSwitchMode>();
            //currentMode = playerManager.defaultCameraMode;
            // set default currentMode from playerManager

        }
        void Start() {
            //GetComponent<PlayerSwitchMode>().ActivityStart();
        }

        void Update() {

        }
        // run switchmode check
    }
}