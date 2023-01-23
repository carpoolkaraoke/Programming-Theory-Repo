using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore
{
    public readonly string name;
    public readonly int score;

    public HighScore(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}
