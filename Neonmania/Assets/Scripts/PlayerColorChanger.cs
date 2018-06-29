using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorChanger : MonoBehaviour {


    private Rigidbody rb;
    private int color;

    private void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	private void Update () {
		
	}

    private void SwitchColor() {
        color = (color + 1) % 3;
    }

    public Color GetColor() {
        switch (color) {
            case 0:
                return CMYColor.CYAN.AsColor();
            case 1:
                return CMYColor.MAGENTA.AsColor();
            case 2:
                return CMYColor.YELLOW.AsColor();
            default:
                throw new ArgumentException("Invalid Color Value");
        }
    }
}
