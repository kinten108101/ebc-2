using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class modelManager {
    static void loadModel(GameObject gameobject, string filepath) {}
}
public class Item {
    private int id;
    private string name;
    public Item(int id) {
        this.id = id;
        switch (id) {
            case -1 :
                this.name = "Empty";
                break;
            case 0 :
                this.name = "Gravity Hand";
                break;
        }
    }
}