using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTowerHealth : MonoBehaviour
{
    [SerializeField] private TowerSO towerSO;

    private void Death()
    {
        if (towerSO.health <= 0)
        {
            Destroy(this.gameObject);
            //UIManger.GameOver();
            return;
        }
    }
}
