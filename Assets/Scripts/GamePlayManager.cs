using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayManager : MonoBehaviour
{
    // Visual Game UI variables
    [SerializeField]
    private Text screenText;
    [SerializeField]
    private Text playerLifesText;
    [SerializeField]
    private Text enemyLifesText;
    public int playerLifes = 3;
    public int enemyLifes = 3;

    // Player controls UI variables
    [SerializeField]
    private Transform buttonsBox;
    [SerializeField]
    private Button button;
    private int flameIndex;
    private int comebackIndex;

    // Game management variables
    private AllSentences allSentences = new AllSentences();
    private bool playerStarts = false;
    private int playerAttack = 0;
    private int enemyAttack = 0;

    private void Start()
    {
        initializeParameters();
        firstTurn();
        Assault();
    }

    // method to initalize all the parameters
    private void initializeParameters()
    {
        // Debug.Log("Player Lifes: " + playerLifes); -> debug manual
        PlayerPrefs.SetInt("PlayerAttack", 0);
        PlayerPrefs.SetInt("EnemyAttack", 0);
        PlayerPrefs.SetInt("PlayerLifes", playerLifes);
        PlayerPrefs.SetInt("EnemyLifes", enemyLifes);
    } // Used playerprefs to save data and collect into others scenes

    // Every frame we are updating the lifes text
    private void Update()
    {
        playerLifesText.text= "Player Lifes\n" + playerLifes;
        enemyLifesText.text= "Enemy Lifes\n" + enemyLifes;
    }

    // On the first turn, the first attacker is random
    private void firstTurn()
    {
        playerLifes = 3;
        enemyLifes = 3;

        //Se comprueba quién comienza la partida
        int random = Random.Range(0, 2);
        
        if(random == 0)
        {
            playerStarts = true;
        }
        else
        {
            playerStarts = false;
        }
    }

    private void Assault()
    {

        // initalize index
        flameIndex = 0;
        comebackIndex = 0;

        // and clean the current buttons
        CleanButtons();

        // if the player starts the assault, add the falme buttons in the box
        if (playerStarts)
        {
            screenText.text = "El jugador tiene algo que decir:";
            AddButtons(allSentences.FlameSentences);
        }
        // if not, enemy says a random flame
        else
        {
            var randomQuestion = Random.Range(0, allSentences.FlameSentences.Length);
            screenText.text = "El enemigo te insulta:\n\n " + allSentences.FlameSentences[randomQuestion];
            flameIndex = randomQuestion;

            // after enemy flames, box is filled with comeback buttons
            AddButtons(allSentences.Comebacks);
        }
    }

    // method to clean the button box
    private void CleanButtons()
    {
        playerAttack = 0;
        enemyAttack = 0;

        PlayerPrefs.SetInt("PlayerAttack", playerAttack);
        PlayerPrefs.SetInt("EnemyAttack", enemyAttack);
        
        foreach (Transform button in buttonsBox.transform)
        {
            Destroy(button.gameObject);
        }
    }

    // method to fill the button box
    private void AddButtons(string [] questionAnswer)
    {
        var y = 0;
        var index = 0;

        // fill one by one
        foreach (var question in questionAnswer)
        {
            // instantiante the button prefab so we can add as many buttons as needed
            var buttonSelectionCopy = Instantiate(button, buttonsBox, true);
            buttonSelectionCopy.GetComponent<RectTransform>().localPosition = new Vector3(-18, y, 0);
           
            ButtonListener(buttonSelectionCopy.GetComponent<Button>(), index);
            
            buttonSelectionCopy.GetComponentInChildren<Text>().text = question;

            // the next button is 30 px below
            y -= 30;
            index++;
        }
    }

    // method to create de button listener
    private void ButtonListener(Button button, int index)
    {
        button.onClick.AddListener(() => {

            playerAttack = 0;
            enemyAttack = 0;

            // if player starts the assault, we'll go with flames index
            if (playerStarts)
            { 
                flameIndex = index;

                // And the enemy uses a random comeback
                var randomComeback = Random.Range(0, allSentences.FlameSentences.Length);
                screenText.text = "El enemigo dice:\n\n " + allSentences.Comebacks[randomComeback];
                comebackIndex = randomComeback;

                // if enemy comebacks correctly, player loses a life, otherwise, enemy loses a life
                if(allSentences.CorrectAnswer(flameIndex, comebackIndex))
                {
                    playerStarts = false;
                    enemyAttack = 1;
                    playerLifes--;
                }
                else
                {
                    playerStarts = true;
                    playerAttack = 1;
                    enemyLifes--;
                }

                //Debug.Log(playerStarts); -> Manual debug
            }
            //if enemy starts the assault, we'll go with comebacks index
            else
            {
                comebackIndex = index;
                screenText.text = "";

                // if we comeback correctly, enemy loses life. Otherwise, player loses life
                if (allSentences.CorrectAnswer(flameIndex, comebackIndex))
                {
                    playerAttack = 1;
                    enemyLifes--;
                    playerStarts = true;
                }
                else
                {
                    enemyAttack = 1;
                    playerLifes--;
                    playerStarts = false;
                }

                //Debug.Log(playerStarts); -> manual debug
                
            }

            // if one of them has no lifes, we will go to the End Game scene and reset characters lifes for a new game if wanted
            if (playerLifes <= 0 || enemyLifes <= 0)
            {
                StartCoroutine(WaitingTime(3));
            }
            else
            {
                // The animations will take the data and play them, after 1 second a new assault will begin
                Invoke("Assault", 4);
            }

            // update the prefs values
            PlayerPrefs.SetInt("PlayerAttack", playerAttack);
            PlayerPrefs.SetInt("EnemyAttack", enemyAttack);
            PlayerPrefs.SetInt("PlayerLifes", playerLifes);
            PlayerPrefs.SetInt("EnemyLifes", enemyLifes);
        });
    }
    
    // coroutine to wait before loading end game scene
    IEnumerator WaitingTime(int delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene("EndGame");
    }
}