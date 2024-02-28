using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  public Text scoreText;

  public Player player;

  public float respawnTime = 3.0f;

  public float respawnInvulnerabilityTime = 3.0f;

  public int lives = 3;

  public int score = 0;
  
  public void AsteroidDestroyed(Asteroid asteroid) 
  {
    if (asteroid.size < 0.75f) {
      this.score += 100; 
    } else if (asteroid.size < 1.0f) {
      this.score += 50; 
    } else {
      this.score += 25; 
    }
    UpdateScoreUI();
  }


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
    this.lives = 3;
    this.score = 0;
    Invoke(nameof(Respawn), this.respawnTime);
  }
 
  void UpdateScoreUI()
  {
    if (scoreText != null)
    {
      scoreText.text = "Score: " + score.ToString();
    }
  }
}