using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NouvelEnemie", menuName = "Scriptable Objects/Enemies")]
public class EnemySO : ScriptableObject {

    [Range(25f, 250f)]
    [Tooltip("Points de vie")]
    public float pointDeVie = 25f;

    [Range(0.1f, 1f)]
    [Tooltip("Vitesse du déplacement")]
    public float vitesse = 0.5f;

    [Range(5, 500)]
    [Tooltip("Nombre de point lorsque détruit")]
    public int nbPoints = 1;
}
