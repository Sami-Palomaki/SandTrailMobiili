using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.down * speed;
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // JOS t�rm�ys objektissa on komponentti nimelt� "PlayerController"
        if(collision.gameObject.GetComponent<PlayerController>())
        {
            // Kutsutaan PlayerController skriptin GameOver metodia
            collision.gameObject.GetComponent<PlayerController>().GameOver();
        }

        // Tuhotaan t�m� peliobjekti kun t�rm�t��n mihin vaan collideriin
        Destroy(this.gameObject);
    }
}
