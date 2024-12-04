using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NouvelEnemie", menuName = "Scriptable Objects/Enemies")]
public class EnemySO : ScriptableObject {

    [Header("Attributs de l'enemie")]
    [Range(25f, 250f)]
    [Tooltip("Points de vie")]
    public float pointsDeVie = 25f;

    [Range(0.1f, 1f)]
    [Tooltip("Vitesse du mouvement")]
    public float vitesseMouvement = 0.5f;

    [Range(5, 500)]
    [Tooltip("Nombre de point lorsque détruit")]
    public int nbPoints = 5;

    [Header("Attributs des projectiles")]
    [Range(0.1f, 25)]
    [Tooltip("Vitesse de tir")]
    public float vitesseTir = 1;
    
    [Range(1, 5)]
    [Tooltip("Distance où l'enemis commence à tirer")]
    public float rangeTir = 1;
}
