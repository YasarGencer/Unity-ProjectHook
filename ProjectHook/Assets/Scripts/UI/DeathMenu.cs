using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathMenu : MonoBehaviour
{
    GameObject player;
    [SerializeField] private TextMeshProUGUI hscoreText;
    Camera cam;

    private void Awake() {
        Die();
    }
    public void Die(){
        cam = Camera.main;
        GetComponent<Canvas>().worldCamera = cam;
        ScoreManager.SetHigscore();
        hscoreText.text = ScoreManager.GetHighscore().ToString();
        DeathManager.isDead = true;
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<BoxCollider2D>().isTrigger = true;
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.None;
        rb.AddTorque(-30f);
        rb.gravityScale = 0.3f;
        player.GetComponent<PlayerMovement>().SetActiveArrow(false);
    }
    public void UnDie(){
        DeathManager.isDead = false;
    }
    public void Restart(){
        UnDie();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu(){
        UnDie();
        SceneManager.LoadScene(0);
    }
}
