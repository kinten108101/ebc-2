using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuButton : MonoBehaviour
{
    [SerializeField]private GameObject menuCollection;
    public void onClick() {
        menuCollection.SetActive(!menuCollection.activeInHierarchy);
    }
}
