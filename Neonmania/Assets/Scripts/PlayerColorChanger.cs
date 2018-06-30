using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorChanger : MonoBehaviour {

    private Rigidbody rb;
    private int color = 1;

    private void Start () {
        rb = GetComponent<Rigidbody>();
        color = UnityEngine.Random.Range(0, 3);
        ApplyColor(GetColor());
	}

    public void SwitchColor() {
        color = (color + 1) % 3;
        ApplyColor(GetColor());
    }

    public CMYColor GetColor() {
        switch (color) {
            case 0:
                return CMYColor.CYAN;
            case 1:
                return CMYColor.MAGENTA;
            case 2:
                return CMYColor.YELLOW;
            default:
                throw new ArgumentException("Invalid Color Value");
        }
    }

    private void ApplyColor(CMYColor color) {
        GetComponent<Renderer>().material.SetColor(Shader.PropertyToID("Color_D1E4B0CA"), color.AsHDRColor(7f));
    }
}
