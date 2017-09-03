using Game.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float movementSpeed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(DataManager.isGameStart)
            transform.Translate(Vector3.up * Time.deltaTime * movementSpeed);

    }
}
