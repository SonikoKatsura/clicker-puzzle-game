using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class ButtonActions : MonoBehaviour {

    public void ToggleSprite(Sprite sprite) {
        GetComponent<Image>().sprite = sprite;
    }

    public void test()
    {
        Debug.Log("WTF");
    }
  
}
