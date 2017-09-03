using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private Vector3 PlayerStart;

    public bool isDied;
    // Use this for initialization
    void Start () {

        isDied = true;
        PlayerStart = new Vector3(0f, -3f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Collision Occured");
        //SceneManager.LoadSceneAsync("GamePlay");
        isDied = true;

    }

    public void ResetPlayer()
    {
        transform.position = PlayerStart;
        isDied = true;
    }
}
