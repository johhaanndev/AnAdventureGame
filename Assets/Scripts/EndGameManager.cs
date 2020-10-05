using UnityEngine;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour
{
    [SerializeField]
    private Text result;
    private int playerLifes;
    private int enemyLifes;

    private void Awake()
    {
        GetCharactersLifes();
        WinnerManager();
    }

    // get the lifes value of characters
    private void GetCharactersLifes()
    {
        playerLifes = PlayerPrefs.GetInt("PlayerLifes");
        enemyLifes = PlayerPrefs.GetInt("EnemyLifes");
    }

    // check who has 0 lifes and say if the player win
    private void WinnerManager()
    {
        
        if (playerLifes == 0)
        {
            result.text = "YOU LOSE";
            //Debug.Log("Enemy wins"); -> Manual debug
        }
        else if (enemyLifes == 0)
        {
            result.text = "YOU WIN";
            //Debug.Log("Player wins"); -> Manual Debug
        }            
    }
}
