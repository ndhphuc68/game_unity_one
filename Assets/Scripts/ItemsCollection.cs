using UnityEngine;
using UnityEngine.UI;

public class ItemsColletion : MonoBehaviour
{

    [SerializeField] private Text score;

    [SerializeField] private AudioSource audioSource;

    private int scrore = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            audioSource.Play();
            Destroy(collision.gameObject);
            scrore++;
            score.text = "Score: " + scrore;
        }
    }
}
