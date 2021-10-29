using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "myEnemy", menuName = "ScriptableObject/Enemy")]
public class EnemyData : ScriptableObject
{
    public float detectionDistance = 0;
    public float attackDistance = 0;
}
