using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using EBC.Player.Core;
using EBC.Player.Controller.Core;   

// https://stackoverflow.com/questions/41391708/how-to-detect-click-touch-events-on-ui-and-gameobjects

namespace EBC.Player.UI {
    public class viewViewmode : MonoBehaviour
    {
        private PlayerSwitchMode _playerSwitchMode;

        private void Awake() {
            _playerSwitchMode = GetComponentInParent<ControllerUiManager>().playerSwitchMode;
            if (!_playerSwitchMode) Debug.LogError("playerswitchmode is empty",this);
        }
        private void Start() {
            _playerSwitchMode.log();
        }
        public void buttonViewClick(int mode){
            switch (mode) {
                case (int)PlayerViewmode.TOPDOWN:
                // call function from controller.switchmode
                    _playerSwitchMode.modeSet(PlayerViewmode.TOPDOWN);
                    break;
                case (int)PlayerViewmode.DOWNTOP:
                    _playerSwitchMode.modeSet(PlayerViewmode.DOWNTOP);
                    break;
                case (int)PlayerViewmode.VR:
                    _playerSwitchMode.modeSet(PlayerViewmode.VR);
                    break;
                case (int)PlayerViewmode.FREE:
                    _playerSwitchMode.modeSet(PlayerViewmode.FREE);
                    break;
                default:
                    Debug.LogError("Unrecognized mode",this);
                    break;
            }
        }
        public void test() {
            Debug.Log("hi");
        }
    }

}
