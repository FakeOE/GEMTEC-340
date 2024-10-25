
using UnityEngine;

public class Apple : MonoBehaviour
{
    public BoxCollider2D Area;
    private Snake _snake;
    

    private void Start()
    {
        RandomizePosition();
    }
    
    private void Awake()
    {
        _snake=FindObjectOfType<Snake>();
    }

    private void RandomizePosition()
    {
        Bounds bounds = Area.bounds;
        
        float x=Random.Range(bounds.min.x, bounds.max.x);
        float y=Random.Range(bounds.min.y, bounds.max.y);
        
        transform.position= new Vector3(Mathf.Round(x),Mathf.Round(y),0);
        /*while (_snake.Occupy(x, y))
        {
            x++;
            if (x > bounds.max.x)
            {
                x = bounds.min.x;
                y++;
                if (y > bounds.max.y)
                {
                    y = bounds.min.y;
                }
            }
        }*/
    }

    

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            RandomizePosition();
        }
    }
    
}
