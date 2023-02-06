using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public int point;
    private void Update()
    {
        SelfDestroy();
    }
    private void SelfDestroy()
    {
        if (transform.position.y < -10)
            Destroy(gameObject);
    }
}
