using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EBC.Player.Controller.Core {
    public class EditManager : MonoBehaviour
    {
        [SerializeField]private Camera EditCamera;
        public Camera editCam {
            get {
                return EditCamera;
            }
            set {
                EditCamera = value;
            }
        }
    }
}