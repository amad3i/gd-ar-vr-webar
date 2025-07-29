using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour
{
    [SerializeField] private Image[] lifePoints;
    [SerializeField] private Color[] lifeColors;
    public int Health = 6;
    [SerializeField] private float Speed;
    [SerializeField] private float maxY;
    [SerializeField] private float minY;
    [SerializeField] private float maxX;
    [SerializeField] private float minX;
    
    public int PlayerDamage;
    private SpriteRenderer Visible;

    void Start() 
    {
        Visible = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update() 
    {
        Vector2 curPos = transform.localPosition;
        curPos.y = Mathf.Clamp(transform.localPosition.y, minY, maxY);
        curPos.x = Mathf.Clamp(transform.localPosition.x, minX, maxX);
        transform.localPosition = curPos;
    }


    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("enemyB"))
        {    
            Damage(1);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Damage(2);
        }
    }

    public void LifeChange()
    {
        for (int i = 0; i < lifePoints.Length; i++)
        {
            if(i < Health)
            {
                lifePoints[i].color = lifeColors[0];
            }
            else 
            {
                lifePoints[i].color = lifeColors[1];
            } 
        }
    }
    public void Damage(int DamageAmount)
    {
        Health -= DamageAmount;
        StartCoroutine(ShowDamage());
        
        if (Health <= 0)
        {
            GameOver();
        }
        LifeChange();

    }

    public void Move(Vector2 dir)
    {
        transform.Translate(dir*Speed*Time.deltaTime);
    }

    public void GameOver()
    {
        Application.LoadLevel("GameOver");
    }


    IEnumerator ShowDamage()
    {
        int i = 0;
        while (i < 3)
        {
            yield return new WaitForSeconds(.1f);
            Visible.enabled = false;
            yield return new WaitForSeconds(.1f);
            Visible.enabled = true;
            i++;
        }
    }
}

