using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCollision : MonoBehaviour
{
    public Player movement;
    public GameManager gameManager;
    void OnCollisionEnter(Collision collisioninfo) 
    {
        if (collisioninfo.collider.tag == "Obstacle")
        {
            movement.enabled=false;
            SceneManager.LoadScene("Game_Over");
        }
    }
}
