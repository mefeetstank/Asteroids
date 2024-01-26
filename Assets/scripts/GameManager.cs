using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  public Player player;

  public float respawnTime = 3.0f;

  public float respawnInvulnerabilityTime = 3.0f;

  public int lives = 3;

  //private int score = 0;
  

  public void PlayerDied()
    {
       this.lives--;

       if (this.lives <= 0) {
       GameOver();
       } else {
            Invoke(nameof(Respawn), this.respawnTime);
       }
    }

  
  private void Respawn()
  {
    this.player.gameObject.layer = LayerMask.NameToLayer("Ignore Collisions"); 
    this.player.transform.position = Vector3.zero;
    this.player.gameObject.SetActive(true);

    Invoke(nameof(TurnOnCollision), this.respawnInvulnerabilityTime);
  }

  private void TurnOnCollision()
  {
     this.player.gameObject.layer = LayerMask.NameToLayer("Player");
  }

  private void GameOver()
  {
    //
  }
}
