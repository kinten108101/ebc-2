using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
//using EBC.Player.Core;

namespace EBC.Player.Controller.Core {
    public class ControllerUiManager : MonoBehaviour
    {
        public PlayerControllerManager playerControllerManager;
        public PlayerSwitchMode playerSwitchMode;
        // current cam that the ui is visible to. Should always be current playercam, 
        private Camera uiCam;
        

        void Awake() {
            
            playerControllerManager = GetComponentInParent<PlayerControllerManager>();
            if (!playerControllerManager) Debug.LogError("empty!",this);
            playerSwitchMode = playerControllerManager.GetComponent<PlayerSwitchMode>();
            if (!playerSwitchMode) Debug.LogError("empty!",this);
        }
        void Update() {
            // due to current implementation approach uiCam must be updated constantly. Is there a better way?
            // One way to improve this is to use an event system. Must be looked into later.
            // When new mode entered, what about calling a function here?
            
        }
    }
}