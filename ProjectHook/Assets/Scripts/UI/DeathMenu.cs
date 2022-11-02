using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathMenu : MonoBehaviour
{
    GameObject player;
    [SerializeField] private TextMeshProUGUI hscoreText;

    private void Awake() {
        Die();
    }
    public void Die(){
        hscoreText.text = PlayerPrefs.GetInt(ScoreManager.highscoreT, 0).ToString();
        DeathManager.isDead = true;
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<BoxCollider2D>().isTrigger = true;
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.None;
        rb.AddTorque(30f);
        rb.gravityScale = 0.3f;
        player.GetComponent<PlayerMovement>().SetActiveArrow(false);
    }
    public void UnDie(){
        DeathManager.isDead = true;
    }
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        UnDie();
    }
    public void MainMenu(){
        SceneManager.LoadScene(0);
        UnDie();
    }
}
