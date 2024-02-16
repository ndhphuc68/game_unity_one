using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] GameObject[] point;

    private SpriteRenderer spriteRenderer;

    private int currentPointIndex = 0;

    [SerializeField] private float speed = 2f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(point[currentPointIndex].transform.position, transform.position) < .1f)
        {
            currentPointIndex++;
            if (currentPointIndex >= point.Length)
            {
                currentPointIndex = 0;
            }

            if(currentPointIndex == 0)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, point[currentPointIndex].transform.position, Time.deltaTime * speed);
    }
}
