using UnityEditor;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float force = 2f;
    public float destroyDelay = 1f;

    private Rigidbody2D rb;
    private Player player;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        
    }
    public void Attract(Player player)
    {
        this.player = player;
    }
    private void FixedUpdate()
    {
        if (player != null)
        {
            AttractMeat();
        }
    }

    private void AttractMeat()
    {
        
         Vector2 direction = (player.transform.position - transform.position);
         rb.AddForce(direction * force);
       
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform == player?.transform)
        {
            
            player.Eat();          
            Destroy(gameObject, destroyDelay);
        }
    }
}


