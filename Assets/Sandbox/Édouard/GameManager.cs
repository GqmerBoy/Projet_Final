using UnityEngine;

public class GameManager : MonoBehaviour
{
    private EnemySO enemySO;

    void Start()
    {
        enemySO.nbPoints = 0; // Initialiser les points à 0
    }

    // Méthode pour ajouter des points au joueur
    public void AjouterPoints(int pointsGagnes)
    {
        enemySO.nbPoints += pointsGagnes;
        Debug.Log("Points du joueur: " + pointsGagnes);
    }
}
