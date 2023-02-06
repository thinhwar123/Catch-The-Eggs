using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public GameManager gameManager;
    private void Update()
    {
        HandleMouseInput();
    }

    private void HandleMouseInput()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.x = Mathf.Clamp(position.x, -2, 2);
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
            gameManager.AddScore(egg.point);
            Destroy(egg.gameObject);
        }
    }
}
