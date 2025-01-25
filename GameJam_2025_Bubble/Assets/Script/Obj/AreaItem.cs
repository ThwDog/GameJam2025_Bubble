using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaItem : MonoBehaviour
{
    public List<GameObject> _resetItem;

    public void activeItem(){
        foreach(var _reset in _resetItem){
            var i = _reset.GetComponent<IResetable>();
            i._reset();
            Debug.Log(_reset.gameObject.name);
            Debug.Log(i);
            
        }
    }
}
