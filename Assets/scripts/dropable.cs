using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropable : MonoBehaviour {

    [HideInInspector] public dropper _dropper;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("dropable"))
        {
            print("cant drop");
            _dropper.canDrop = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("dropable"))
        {
            print("can drop");
            _dropper.canDrop = true;
        }
    }
}
