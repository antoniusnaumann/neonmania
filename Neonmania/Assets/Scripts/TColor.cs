using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TColor {

    public static readonly TColor
        CYAN = new TColor(1),
        MAGENTA = new TColor(2),
        YELLOW = new TColor(4),
        RED = new TColor(6),
        GREEN = new TColor(5),
        BLUE = new TColor(3),
        WHITE = new TColor(0),
        BLACK = new TColor(7);

    private int color;
    

    private TColor(int color) {
        this.color = color;
    }

    private int GetValue() {
        return color;
    }

    public static TColor operator+(TColor c1, TColor c2) {
        int mixValue = c1.GetValue() + c2.GetValue();

        if (mixValue > BLACK.GetValue() && (
            IsPrimary(c1) && IsSecondary(c2) || IsSecondary(c1) && IsPrimary(c2))) {
            return IsPrimary(c1) ? c1 : c2;
        } else if (mixValue > BLACK.GetValue()) {
            return BLACK;
        }

        return new TColor(mixValue);
    }

    private static bool IsPrimary(TColor c) {
        return c == CYAN || c == MAGENTA || c == YELLOW || c == WHITE;
    }

    private static bool IsSecondary(TColor c) {
        return c == RED || c == GREEN || c == BLUE;
    }

    public override bool Equals(object obj) {
        var color = obj as TColor;
        return color != null &&
               this.color == color.color;
    }

    public override int GetHashCode() {
        return 790427672 + color.GetHashCode();
    }

    public static bool operator >(TColor c1, TColor c2) {
        return c1.GetValue() > c2.GetValue();
    }

    public static bool operator <(TColor c1, TColor c2) {
        return c1.GetValue() < c2.GetValue();
    }

    public static bool operator==(TColor c1, TColor c2) {
        return c1.GetValue() == c2.GetValue();
    }

    public static bool operator !=(TColor c1, TColor c2) {
        return c1.GetValue() != c2.GetValue();
    }

    
}
