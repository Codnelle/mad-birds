
using UnityEngine;

public class monsters : MonoBehaviour
{
    [SerializeField] private GameObject _cloudparticleprefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bird bird = collision.collider.GetComponent<Bird>();
        if(bird!= null)
        {
            Instantiate(_cloudparticleprefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        monsters monsterr = collision.collider.GetComponent<monsters>();
        if(monsterr != null)
        {
            Destroy(gameObject);
        }
        if( collision.contacts[0].normal.y < -0.5 )
        {
            Instantiate(_cloudparticleprefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    
}
