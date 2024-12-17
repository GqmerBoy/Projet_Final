using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NouveauProjectile", menuName = "Scriptable Objects/Tourelles")]

public class TurretSO : ScriptableObject
{
    [Range(1, 10)]
    [Tooltip("Vitesse de rotation")]
    public float vitesseRotation = 7.5f;

    [Range(0.01f, 5)]
    [Tooltip("Fréquence de tir/sec")]
    public float vitesseTir = 1;

    [Range(0.5f, 5)]
    [Tooltip("Distance à laquelle la tourelle voit un enemie")]
    public float rangeTir = 1;
}
