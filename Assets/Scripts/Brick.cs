
using UnityEngine;

public class Brick : MonoBehaviour
{

    public SpriteRenderer spriteRenderer{get; private set;}
    public Sprite[] sprites;
    public int health;
    public int points = 200;
    public bool isUnbreakable;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(!isUnbreakable){
            health = sprites.Length;       
            spriteRenderer.sprite = sprites[health - 1];
        }
    }


    void Hit(){
        if(isUnbreakable) return;
        health --;
        if(health <= 0){
            gameObject.SetActive(false);
        }else{
            spriteRenderer.sprite = sprites[health - 1];    
        }
        FindObjectOfType<GameManager>().Hit(this);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ball"){
            Hit();
        }
    }
    

}
