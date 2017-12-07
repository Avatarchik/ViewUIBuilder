using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViewUIBuilder.Helpers.Components.Log;

public class GameController : MonoBehaviour {

    public GameObject views;

    // Use this for initialization
    void Start () {
        Log.Initialize(gameObject);
        UIBuilder.Initialize(gameObject, views);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
