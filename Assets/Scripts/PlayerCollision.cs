using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public 
    void OnCollisionEnter (Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Enemy")
            {
                PlayerController.isGameOver = true;
            }
        
    }
}
