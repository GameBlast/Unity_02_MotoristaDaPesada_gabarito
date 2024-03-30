using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulo : MonoBehaviour
{
    public float forca;

    // Update is called once per frame
    void Update()
    {
        Vector2 size = gameObject.GetComponent<SpriteRenderer>().size;
        Vector2 bounds_size = gameObject.GetComponent<SpriteRenderer>().bounds.size;
        Vector2 diferenca = bounds_size - size;

        int inclinacaoCarro;
        if (transform.eulerAngles.z < (360 - transform.eulerAngles.z))
            inclinacaoCarro = 1;
        else
            inclinacaoCarro = -1;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit2D hitRodaDir = 
                    Physics2D.Raycast(transform.position + new Vector3(1 - (diferenca.x / 2), diferenca.y / 2 * inclinacaoCarro, 0),
                    transform.TransformDirection(Vector3.down), 0.95f, LayerMask.GetMask("Piso"));
                RaycastHit2D hitRodaEsq = 
                    Physics2D.Raycast(transform.position + new Vector3(-1 + (diferenca.x / 2), -diferenca.y / 2 * inclinacaoCarro, 0),
                    transform.TransformDirection(Vector3.down), 0.95f, LayerMask.GetMask("Piso"));

            if (hitRodaDir.collider != null || hitRodaEsq.collider != null)
            {
                Vector2 sentidoCima = new Vector2(0, 1);
                gameObject.GetComponent<Rigidbody2D>().AddForce(sentidoCima * forca);
            }                
        }
    }
}