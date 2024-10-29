using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapProblem : MonoBehaviour
{
    public Vector2 square1Pos;
    public Vector2 square2Pos;
    public float squareWidth = 1;

    // Start is called before the first frame update
    void Start()
    {
        Calculate();
    }

    void Calculate()
    {
        float s1x1 = square1Pos.x - squareWidth / 2f;
        float s1x2 = square1Pos.x + squareWidth / 2f;
        float s1y1 = square1Pos.y - squareWidth / 2f;
        float s1y2 = square1Pos.y + squareWidth / 2f;

        float s2x1 = square2Pos.x - squareWidth / 2f;
        float s2x2 = square2Pos.x + squareWidth / 2f;
        float s2y1 = square2Pos.y - squareWidth / 2f;
        float s2y2 = square2Pos.y + squareWidth / 2f;

        float diffX1 = s2x1 - s1x1;
        float diffX2 = s2x2 - s1x2;
        float diffY1 = s2y1 - s1y1;
        float diffY2 = s2y2 - s1y2;

        Debug.Log(diffX1 + " | " + diffX2 + " | " + diffY1 + " | " + diffY2);
    }
}
