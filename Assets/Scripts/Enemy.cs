using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject _cloudParticalesPrefab = null;
    
    static public int _numberOfActiveEnemies = 0;

    private void OnCollisionEnter2D( Collision2D collision )
    {


        if( collision.gameObject.CompareTag("Player") || collision.GetContact(0).normal.y < -0.5f)
        {
            Instantiate( _cloudParticalesPrefab , collision.contacts[0].point , Quaternion.identity );
            Destroy( gameObject );
            return;
        }


    }

    private void OnEnable()
    {
        _numberOfActiveEnemies++;
    }


    private void OnDisable()
    {
        _numberOfActiveEnemies--;
    }

}
