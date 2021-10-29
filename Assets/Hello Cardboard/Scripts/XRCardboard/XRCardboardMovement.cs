using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class XRCardboardMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] XRCardboardInputSettings settings = default;
    private int key_ws, key_ad;
    public int keyWS {
        set {
            key_ws = value;
        }
    } 
    
    [SerializeField]private GameObject playerModel;
    private Camera mainCamera;
    private playerManager mManager;
    // Update is called once per frame
    void Start(){
        
        
        mManager = this.GetComponent<playerManager>();
        if (!mManager) throw new UnityException("Camera in PlayerManager is empty.");
        // remember that this is a reference (transform is a component)
        mainCamera = mManager.Camera;
        if (mainCamera == null) throw new UnityException("Camera in PlayerManager is empty.");
        
        
    }
    void FixedUpdate()
    {
        if (Input.GetButton(settings.ClickInput) || (Input.touchCount ==2)){
            keyWS = 1;
        }
        else keyWS = 0;
        
        this.transform.position += (Vector3.Scale(mainCamera.transform.forward, new Vector3(1f,0f,1f)).normalized
            *key_ws*settings.forwardSpeed 
            + mainCamera.transform.right * key_ad * settings.sideSpeed)
            *Time.deltaTime;
        
    }
}
