using UnityEngine;

public class Ball : MonoBehaviour
{
    
    public Rigidbody2D rigidbody{get; private set;}
    public float speed = 500f;
    

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Reset();
    }

    public void Reset()
    {
        transform.position = Vector2.zero;
        rigidbody.velocity = Vector2.zero;

        Invoke(nameof(SetRandomTrajectory),1f);   
    }

    void SetRandomTrajectory(){
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f,1f);
        force.y = -1f;
        rigidbody.AddForce(force.normalized * speed);
    }

    


}
