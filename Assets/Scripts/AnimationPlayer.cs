using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    private Animator animator;

    void Start()
    { 
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        // recieve if the enemy is attacking and set the animator parameter
        if (PlayerPrefs.GetInt("PlayerAttack") == 1)
        {
            animator.SetBool("PlayerAttack", true);
        }
        else
        {
            animator.SetBool("PlayerAttack", false);
        }

        // check if player is dead
        if (PlayerPrefs.GetInt("PlayerLifes") == 0)
        {
            animator.SetInteger("PlayerLifeAnim", 0);
        }
        else
        {
            animator.SetInteger("PlayerLifeAnim", PlayerPrefs.GetInt("PlayerLifes"));
        }
    }
}
