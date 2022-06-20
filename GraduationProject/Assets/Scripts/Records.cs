using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Create Record",menuName ="Records")]
public class Records : ScriptableObject
{
    public int score;
    public int goal;
    public int arrows;
}
