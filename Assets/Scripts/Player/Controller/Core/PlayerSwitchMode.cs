using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EBC.Player.Core;

namespace EBC.Player.Controller.Core {
    public class PlayerSwitchMode : MonoBehaviour
    {
        
        
        private PlayerControllerManager _controller;
        
        // the only way to switch between cameras is to use them in turns.
        [SerializeField]private GameObject _xrRig;
        [SerializeField]private GameObject _editRig;
        
        void Awake() {
            _controller = GetComponent<PlayerControllerManager>();
        }
        public void log() {
            Debug.Log("Entered playerSwitchmode",this);
        }
        void Update() {
            modeCheck();
            //modeUpdate();
        }
        void modeCheck(){
            // sending a broadcast message with info of cam orientation
            PlayerViewmode currentMode = _controller.currentMode;
            PlayerViewmode lastMode = _controller.lastMode;
            
            if (Input.GetKeyDown(_controller.inputCamVr))
            {
                currentMode = PlayerViewmode.VR;                
                if (lastMode == PlayerViewmode.VR) return; 
                Debug.Log("entering VR Mode");
                modeUpdate();
                
            }
            else if (Input.GetKeyDown(_controller.inputCamNone))
            {
                currentMode = PlayerViewmode.FREE;
                if (lastMode == PlayerViewmode.FREE) return;
                Debug.Log("entering Edit Mode Free");
                modeUpdate();
                
            }
            else if (Input.GetKeyDown(_controller.inputCamTop))
            {
                currentMode = PlayerViewmode.TOPDOWN;
                if (lastMode != PlayerViewmode.TOPDOWN) return;
                Debug.Log("entering Edit Mode Topdown");
                modeUpdate();
                
            }
        }
        public void modeSet(PlayerViewmode mode) {
            _controller.AddToModeStack(mode);
            _controller.currentMode = _controller.cameraModeStack[1];
            _controller.lastMode = _controller.cameraModeStack[0];
            modeUpdate();
        }
        
        void modeUpdate() {
            switch(_controller.currentMode) {
                case PlayerViewmode.VR:
                    Debug.Log("entering VR");
                    _xrRig.SetActive(true);
                    _editRig.SetActive(false);
                    SetCanvasCamera(_controller.xrManager.xrCam);
                    break;
                case PlayerViewmode.FREE:
                    Debug.Log("Entering freecam!");
                    _xrRig.SetActive(false);
                    _editRig.SetActive(true);
                    SetCanvasCamera(_controller.editManager.editCam);
                    break;
                case PlayerViewmode.TOPDOWN:
                    Debug.Log("entering Topdown");
                    break;
                case PlayerViewmode.DOWNTOP:
                    Debug.Log("entering Downtop!");
                    break;
            }
        }
        
        private void SetCanvasCamera(Camera cam){
            //ControllerUiManager.GetComponent<Canvas>().
        }
    }
}