using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTowerHealth : MonoBehaviour
{
   [HideInInspector] public float health = 1000f;

    private void Death()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
            //UIManger.GameOver();
            return;
        }
    }
}
