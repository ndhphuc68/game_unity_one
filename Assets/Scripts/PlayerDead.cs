using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDead : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidbody;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Trap"))
        {
            Dead();
        }

    }

    private void Dead()
    {
        rigidbody.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("player_dead");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
