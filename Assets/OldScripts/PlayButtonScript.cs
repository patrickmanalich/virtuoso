﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonScript : MonoBehaviour {

    private Vector3 screenPoint;
    private Vector3 offset;
    public GameObject toy;
    private ToyScript toyScript;
    public GameObject playButtonText;

    void Awake() {
        toyScript = toy.GetComponent<ToyScript>();
    }

    void OnMouseDown() {
        if (toyScript.isAnimationRecorded) {
            if (GetComponent<Renderer>().material.color == Color.red)  // Bad implementation, should either pull from resources or access array of materials
                ChangeState(true);
            else
                ChangeState(false);
        } else
            Debug.Log("No animation has been recorded");
    }

    public void ChangeState(bool on) {
        if (on) {
            GetComponent<Renderer>().material.color = Color.green;
            playButtonText.GetComponent<TextMesh>().text = ">";
            //toyScript.DebugInstantiateSamples();
            toyScript.StartPlaying();
        } else {
            GetComponent<Renderer>().material.color = Color.red;
            playButtonText.GetComponent<TextMesh>().text = "||";
            //toyScript.DebugDestroySamples();
            toyScript.StopPlaying();
        }
    }

}