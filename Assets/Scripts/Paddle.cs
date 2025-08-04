using UnityEngine;

public class Paddle : MonoBehaviour
{

    public Rigidbody2D rigidbody{get; private set;}
    public Vector2 direction{get; private set;}
    public float speed = 30f;
    public float maxBounceAngle = 75f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            direction = Vector2.left;
        }else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
           direction = Vector2.right;
        }else{
            direction = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        if(direction != Vector2.zero){

        }
        rigidbody.AddForce(direction * speed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();  
        if(ball != null){
            SoundManager.Instance.PlaySound("HitPaddle");
            
            Vector3 paddlePosition = transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            float offset = paddlePosition.x - contactPoint.x;
            float width = collision.otherCollider.bounds.size.x /2 ;
            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.rigidbody.velocity);
            float bounceAngle = (offset / width) * maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle , -maxBounceAngle , maxBounceAngle);
            
            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.rigidbody.velocity = rotation * Vector2.up * ball.rigidbody.velocity.magnitude;
        }
    }



    public void Reset(){
        transform.position = new Vector2(0f,transform.position.y);
        rigidbody.velocity = Vector2.zero;
    }

}
