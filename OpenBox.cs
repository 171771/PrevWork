using UnityEngine;
using System.Collections;

public class OpenBox : MonoBehaviour {

    private Animator animator;

    private Ray ray;
    private RaycastHit hit;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	} 
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit, 2))
            {
                if (hit.collider.tag == "BOX" && PickKey.keyCount > 0)
                {
                    Debug.Log("collider tag = " + hit.collider.tag);
                    animator.SetBool("IsOpen", true);
                    PickKey.keyCount--;
                }
            }
        }
    }
}
