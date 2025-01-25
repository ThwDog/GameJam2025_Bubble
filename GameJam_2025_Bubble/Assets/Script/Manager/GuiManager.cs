using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiManager : MonoBehaviour
{
    public bool cheat = true;

    private void OnGUI() {
        if (GUI.Button(new Rect(500, 500, 100, 100), "NextScene")){
            _SceneManager.instance._nextScene();
        }
    } 

    public void setCheat(bool _bool){
        cheat = _bool;
    }
}
