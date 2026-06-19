using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;
    [SerializeField] int hitpoints = 3;
    [SerializeField] int scoreValue = 10;

    GameScoreboard scoreboard;    
    private void Start()
    {
        scoreboard = FindFirstObjectByType<GameScoreboard>();
    }

    private void OnParticleCollision(GameObject other)
    {        
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitpoints--;

        if (hitpoints <= 0)
        {
            scoreboard.IncreaseScore(scoreValue);
            Instantiate(destroyedVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}