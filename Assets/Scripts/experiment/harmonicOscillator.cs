using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class harmonicOscillator : MonoBehaviour
{
    [SerializeField]private Vector3 startPos;
    [Range(-1f,1f)][SerializeField]private float startAngle = 0f;
    [SerializeField]private float currentAngle = 2f;
    [SerializeField]private float displacement = 0f;
    [SerializeField]private float time = 0;
    [SerializeField]private GameObject target;
    [SerializeField]private float amplitude = 1f;
    [SerializeField]private float frequency = 1f;
    public bool bSetPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        startPos = target.transform.position;
    }

    // Update is called once per frame
    void Update() {

    }
    void FixedUpdate()
    {
        if (bSetPlaying==true)
        {
            time += Time.fixedDeltaTime;
            var d = calculateDisplacement(amplitude,frequency,time,startAngle);
            target.transform.position = new Vector3(
                target.transform.position.x+d,
                target.transform.position.y,
                target.transform.position.z
            );
        }
    }
    float calculateDisplacement(float A, float f, float t, float phi0) {
        return A*Mathf.Cos(2*Mathf.PI*f*t + phi0*Mathf.PI);
    }
    public void buttonPause(){
        bSetPlaying = false;
    }
    public void buttonPlay() {
        bSetPlaying = true;
        //Debug.Log("bSetplaying="+bSetPlaying);
    }
}
