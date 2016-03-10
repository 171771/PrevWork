using UnityEngine;
using System.Collections;

public class PickKey : MonoBehaviour {

    public static int keyCount;

    private Ray ray;
    private RaycastHit hit;
    
	// Use this for initialization
	void Start () {
        keyCount = 0;
	}

   void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit,2))
            {
                if(hit.collider.tag == "KEY")
                {
                    keyCount++;
                    Destroy(gameObject);
                }
            }
        }
    }
}
