using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EBC.Player.Controller.Core {
// read this: https://stackoverflow.com/questions/831888/custom-primitives-in-c

    public enum XrCursor {
    SELECTED,
    UNSELECTED
    }
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
}