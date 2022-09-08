using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : ProjectileUnitBase
{
    // [SerializeField] private AudioClip _someSound;

    // void Start() {
    //     // Example usage of a static system
    //     AudioSystem.Instance.PlaySound(_someSound);
    // }
    //
    private bool _isReturned = false;
    [SerializeField] private float angularSpeed = 1f;


    private void Update()
    {
        if (!_isReturned)
        {
            ReturnAutomatically();
        }

        RotateBanana();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            Debug.Log("Damage Enemy");
            other.GetComponent<EnemyUnitBase>().TakeDamage(Hero.BaseStats.AttackPower);
            // Destroy(gameObject, 0.05f);
        }

        if (other.transform.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }


    }

    private void HeroThrustBackward(float speed)
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        Vector2 dir = new Vector2(-1, 0);
        // rb.AddForce(dir * speed, ForceMode2D.Force);
        rb.velocity = dir * speed;
    }

    private void RotateBanana()
    {
        float currentRotZ = transform.rotation.z;
        // transform.rotation = Quaternion.Euler(0, 0, currentRotZ + angularSpeed);
        // transform.ang
    }

    private void ReturnAutomatically()
    {
        if (transform.position.x >= 9)
        {
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            Vector2 dir = new Vector2(-1, 0);
            rb.velocity = dir * speed;
            _isReturned = true;
        }
    }

}