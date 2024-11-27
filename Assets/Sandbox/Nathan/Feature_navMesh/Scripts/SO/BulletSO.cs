using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NouveauProjectile", menuName = "Scriptable Objects/Projectiles")]
public class BulletSO : ScriptableObject
{
    [Range(25, 50)]
    [Tooltip("Dommages par projectiles")]
    public float dommages = 25f;

    [Range(25, 100)]
    [Tooltip("Vitesse du projectile")]
    public float vitesse = 75f;
}
