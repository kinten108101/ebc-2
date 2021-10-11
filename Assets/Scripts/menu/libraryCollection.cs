using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class libraryCollection : MonoBehaviour
{
    [SerializeField]private GameObject[] mLibraryItem;
    private GameObject[] mObj;
    void Start() {
        mObj = new GameObject[mLibraryItem.Length];
        for (int i = 0; i<mLibraryItem.Length;i++) {
            mObj[i] = mLibraryItem[i].GetComponent<libraryItem>().GetObj();
        }
    }
}
