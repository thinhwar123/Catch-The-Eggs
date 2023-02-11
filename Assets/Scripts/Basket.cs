using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private void Update()
    {
        HandleMouseInput();
    }

    private void HandleMouseInput()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (position.x > 2)
                position.x = 2;
            if (position.x < -2)
                position.x = -2;
            position.y = transform.position.y;
            position.z = transform.position.z;
            transform.position = position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Egg"))
        {
            Egg egg = collision.GetComponent<Egg>();
            if (egg.Point < 0)
            {
                gameManager.EndGame();
            }
            else
            {
                gameManager.AddScore(egg.Point);
            }
            Destroy(egg.gameObject);
        }
    }
}
