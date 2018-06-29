using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CMYColor {

	public static readonly CMYColor
	CYAN = new CMYColor(1),
		MAGENTA = new CMYColor(2),
		YELLOW = new CMYColor(4),
		RED = new CMYColor(6),
		GREEN = new CMYColor(5),
		BLUE = new CMYColor(3),
		WHITE = new CMYColor(0),
		BLACK = new CMYColor(7);

	private readonly float c, m, y;

	public CMYColor(byte cmy) : this(
		cmy & 0x4,
		cmy & 0x2,
		cmy & 0x1
	) { }

	public CMYColor(bool cyan, bool magenta, bool yellow) : this(
		cyan ? 1.0f : 0.0f,
		magenta ? 1.0f : 0.0f,
		yellow ? 1.0f : 0.0f
	) { }

	public CMYColor(float cyan, float magenta, float yellow) {
		this.c = Mathf.Clamp(cyan, 0.0f, 1.0f);
		this.m = Mathf.Clamp(magenta, 0.0f, 1.0f);
		this.y = Mathf.Clamp(yellow, 0.0f, 1.0f);
	}

	public bool IsBlack() {
		return this.c >= 1 && this.m >= 1 && this.y >= 1;
	}

	public bool IsWhite() {
		return this.c <= 0 && this.m <= 0 && this.y <= 0;
	}

	public static CMYColor operator +(CMYColor c1, CMYColor c2) {
		return new CMYColor(
			c1.c + c2.c,
			c1.m + c2.m,
			c1.y + c2.y
		);
	}

	public static CMYColor operator *(float f, CMYColor c) {
		return new CMYColor(
			f * c.c,
			f * c.m,
			f * c.y
		);
	}

	public Color AsColor() {
		return new Color(1.0f - this.c, 1.0f - this.m, 1.0f - this.y);
	}

}
