using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadoCarrinho : MonoBehaviour
{
    void Update()
    {
        if (Time.timeScale > 0)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                gameObject.GetComponent<SpriteRenderer>().flipX = false;

        }
    }
}
