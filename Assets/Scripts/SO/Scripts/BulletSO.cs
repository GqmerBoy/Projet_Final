using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NouveauProjectile", menuName = "Scriptable Objects/Projectiles")]
public class BulletSO : ScriptableObject
{
    [Range(1, 100)]
    [Tooltip("Dommages par projectiles")]
    public float dommages = 25f;

    [Range(0.5f, 5)]
    [Tooltip("Vitesse du projectile")]
    public float vitesseDeplacement = 75f;
}
