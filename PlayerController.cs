using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    void Update()
    {
        Rigidbody2D _rb = this.transform.GetComponent<Rigidbody2D>();
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;

        _rb.velocity = direction * speed;

    }
}
