using UnityEngine;

public class AnimationEnemy : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // recieve if the enemy is attacking and set the animator parameter
        if (PlayerPrefs.GetInt("EnemyAttack") == 1)
        {
            animator.SetBool("EnemyAttack", true);
        }
        else
        {
            animator.SetBool("EnemyAttack", false);
        }

        // check if the enemy is dead
        if (PlayerPrefs.GetInt("EnemyLifes") == 0)
        {
            animator.SetInteger("EnemyLifeAnim", 0);
        }
        else
        {
            animator.SetInteger("EnemyLifeAnim", PlayerPrefs.GetInt("EnemyLifes"));
        }
    }
}
