using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour {

    public GameObject target;
    Vector3 newTarget;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Vector3.Lerp(transform.position, target.transform.position, 1f);
        newTarget = new Vector3(target.transform.position.x, target.transform.position.y, -10f);
        transform.position = newTarget;
	}



}
