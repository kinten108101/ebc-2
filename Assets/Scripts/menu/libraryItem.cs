using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using EBC.Player.Controller.Core;
public class libraryItem : MonoBehaviour, IPointerClickHandler
{
    public int id;
    public string name;
    public Sprite icon;
    [SerializeField]private GameObject obj;
    public GameObject GetObj(){
        return obj;
    }

    
    private XrManager xrManager;
    void Awake() {
        
    }
    public void OnPointerClick(PointerEventData p) {
        Vector3 pos = xrManager.xrView.GetCursorPosition();
        Instantiate(obj,pos,xrManager.transform.rotation);
    }
    
}
