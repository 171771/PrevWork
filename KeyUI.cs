using UnityEngine;
using System.Collections;

public class KeyUI : MonoBehaviour {

    public GameObject obj;

    void Update()
    {
        if(PickKey.keyCount > 0)
        {
            obj.SetActive(true);
        }
        else
        {
            obj.SetActive(false);
        }
    }
}
