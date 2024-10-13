using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OrcShamanlv2 : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public Animator anim;
    public bool isEnableItem = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isEnableItem = false;
    }

    
    void Update()
    {
        Movement();
        Mirror();
    }

    void Movement()
    {

        if (isEnableItem)
        {
            float x = -Input.GetAxis("Horizontal");
            float y = -Input.GetAxis("Vertical");
            anim.SetFloat("movement", math.abs(x) * speed);
            rb.velocity = new Vector2(x, y) * speed;
        }
        else 
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            anim.SetFloat("movement", math.abs(x) * speed);
            rb.velocity = new Vector2(x, y) * speed;
        }
        
    }

    void Mirror()
    {
        if (rb.velocity.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (rb.velocity.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void InverterMechanic(bool item) 
    {
        if (item) 
        {
            isEnableItem = true;
        }
        else
            isEnableItem = false;
    }

    public IEnumerator DeathPlayer()
    {
        anim.SetBool("life", true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Gamelv2");
    }

    public IEnumerator Reinicio()
    {
        anim.SetBool("life", true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainPrincipal");
    }

    public IEnumerator FinalLv()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("SampleScene");
    }


}
