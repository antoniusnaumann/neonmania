using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoLightScript : MonoBehaviour {

	private Light Light;

	public float hueLoopPeriodInS;

	private void Start() {
		this.Light = GetComponent<Light>();
	}

	private void Update() {
		// UpdateLightHue((Time.time % hueLoopPeriodInS) / hueLoopPeriodInS);
		UpdateLightBrightness(Math.Abs((Time.time % 2) - 1));
	}

	private void UpdateLightHue(float hue) {
		float h, s, v;
		Color.RGBToHSV(this.Light.color, out h, out s, out v);
		this.Light.color = Color.HSVToRGB(hue, s, v);
	}

	private void UpdateLightBrightness(float brightness) {
		float h, s, v;
		Color.RGBToHSV(this.Light.color, out h, out s, out v);
		this.Light.color = Color.HSVToRGB(h, s, brightness);
	}
}
