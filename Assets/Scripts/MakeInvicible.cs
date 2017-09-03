using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeInvicible : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("_Line"))
        {
            // Do setactive false
            Debug.Log("I am in invicible");
            collision.transform.parent.gameObject.SetActive(false);
        }
    }

}
