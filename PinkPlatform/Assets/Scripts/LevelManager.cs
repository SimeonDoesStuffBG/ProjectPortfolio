using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    float RestartDelay = .5f;

    int lives;
    [SerializeField]
    int maxLives = 3;

    [SerializeField]
    Sprite fullHeart;
    [SerializeField]
    Sprite emptyHeart;
    [SerializeField]
    Image[] hearts;

    bool isHurt = false;
    float hurtTimer = 1f;

    private PlayerControler move;

    void Start(){
        lives = maxLives;
        move = GetComponent<PlayerControler>();
    }

    void Update(){

        for(int i = 0; i < maxLives; i++){
            hearts[i].sprite = (i < lives) ? fullHeart : emptyHeart;
        }

        if (isHurt){
            hurtTimer -= Time.deltaTime;
            if (hurtTimer <= 0){
                isHurt = false;
                hurtTimer = 1f;
            }
        }
        if (transform.position.y <= -25)
            GameOver();
    }

    public void Victory(){
        Debug.Log("You win");
        Invoke("Restart", RestartDelay); 
    }

    public void GameOver(){
        transform.Rotate(0, 90, 0);
        Debug.Log("Game over");
        move.enabled = false;
        Invoke("Restart", RestartDelay);
    }

    void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoseLife(){
        lives--;
        isHurt = true;
        if(lives == 0){
            GameOver();
        }
    }

    public bool GetHurt(){
        return isHurt;
    }
}
