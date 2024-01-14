using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level",menuName = "Create Level")]
public class level : ScriptableObject{
    public int minLevel;
    public int nbColors;
    public int[] nbLines;
}
