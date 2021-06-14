using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    

    [SerializeField]private Transform mainCamera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton(settings.ClickInput) || (Input.touchCount ==2)){
            keyWS = 1;
        }
        else keyWS = 0;

        this.transform.position += (Vector3.Scale(mainCamera.forward, new Vector3(1f,0f,1f)).normalized
            *key_ws*settings.forwardSpeed 
            + mainCamera.right * key_ad * settings.sideSpeed)
            *Time.deltaTime;
    }
}
