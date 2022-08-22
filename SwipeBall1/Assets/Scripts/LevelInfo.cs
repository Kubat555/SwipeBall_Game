using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LevelInfo", menuName = "SwipeBall/LevelInfo", order = 0)]
public class LevelInfo : ScriptableObject 
{
    [Header("Player")]
    public Vector3 playerPosition;
    public Material playerMaterial;

    [Header("\nPlane")]
    public Material planeMaterial;
}
