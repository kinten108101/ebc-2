using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class libraryItem : MonoBehaviour, IPointerClickHandler
{
    public int id;
    public string name;
    public Sprite icon;
    [SerializeField]private GameObject obj;
    public GameObject GetObj(){
        return obj;
    }
    
    [SerializeField]private GameObject mPlayerManager;
    
    public void OnPointerClick(PointerEventData p) {
        Vector3 pos = mPlayerManager.GetComponent<playerManager>().GetCursorPosition();
        Instantiate(obj,pos,mPlayerManager.transform.rotation);
    }
    
}
