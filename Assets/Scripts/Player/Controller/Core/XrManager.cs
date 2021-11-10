using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EBC.Player.Core;
using EBC.Player.Controller.ModeXR;

namespace EBC.Player.Controller.Core {

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
}