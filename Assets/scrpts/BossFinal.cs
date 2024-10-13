using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Enemy;

public class BossFinal : MonoBehaviour
{
    [Header("Estadisticas")]
    public float speed = 3f;
    public float life = 20f;
    public float maxlife = 20f;
    public float damage = 2f;
    public float attackRange = 6;
    float timer = 0f;
    public float timeBTWPunch = 2f;
    bool targetInRange = false;
    [Header("References")]
    public Rigidbody2D rb;
    
    public Transform firepoint;
    Transform target;
    public Animator animBody;
    public Image lifebar;
    // Start is called before the first frame update
    void Start()
    {
        lifebar.fillAmount = life / maxlife;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        lifebar.fillAmount = life / maxlife;
        if (!targetInRange)
        {
            SearchTarget();
            NormalMovement();
        }
        else
        {
            RotateToTarget();
            
        }
    }

    void NormalMovement()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        animBody.SetBool("Walk", true);
    }

    void RotateToTarget()
    {
        if (transform.position.x < target.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animBody.SetBool("Punch", false);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animBody.SetBool("Punch", false);
        }
    }

    void SearchTarget()
    {
        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.position);
            if (Mathf.Abs(distance) <= attackRange)
            {
                targetInRange = true;
            }
        }
    }

    public void TakeDamage(float value)
    {
        life -= value;
        if (life <= 0)
        {
            Debug.Log("Se murio el BossFinal");
            Destroy(gameObject);
            SceneManager.LoadScene("Final");
        }
    }

  

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Player p = collision.gameObject.GetComponent<Player>();
    //        p.TakeDamage(damage);
    //        Destroy(gameObject);
    //    }
    //}
}
