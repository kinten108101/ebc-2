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

    [SerializeField]private GameObject mPlayer;
    private playerManager mManager;
    void Awake() {
        mManager = mPlayer.GetComponent<playerManager>();
    }
    public void OnPointerClick(PointerEventData p) {
        Vector3 pos = mManager.playerView.GetCursorPosition();
        Instantiate(obj,pos,mPlayer.transform.rotation);
    }
    
}
