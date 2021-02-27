using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collisionInfo)
    {
        // eğer oyuncu "Obstacle" etiketinde bir objeye çarparsa
        // PlayerController scripti kapanacak. kontrol edilemeyecek.
        if (collisionInfo.collider.tag == "Obstacle"){
            FindObjectOfType<GameManager>().EndGame();
        }

        if (collisionInfo.collider.tag == "Finish")
        {
            FindObjectOfType<GameManager>().LevelFinish();
        }
    }
}
