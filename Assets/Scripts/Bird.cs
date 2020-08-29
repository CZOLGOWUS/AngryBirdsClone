using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{

    Rigidbody2D _thisRigidBody;
    LineRenderer _thisLineRenderer;
    SpriteRenderer _thisSpriteRenderer;




    Vector3 _mousePositionToCamera;
    Vector3 _initialPosition;
    Vector3 _directionToInitialPosition;




    public float launchPower = 100f;

    private bool _isBirdLaunched = false;
    private float _timeSittingStill = 0;
    
    [SerializeField]
    public float timeToRespawn = 1f;




    private void Awake()
    {
        _thisSpriteRenderer = GetComponent<SpriteRenderer>();
        _thisLineRenderer = GetComponent<LineRenderer>();
        _thisRigidBody = GetComponent<Rigidbody2D>();

        _thisRigidBody.isKinematic = true;
        _initialPosition = transform.position;
    }


    private void Update()
    {
        _thisLineRenderer.SetPosition( 0 , transform.position );
        _thisLineRenderer.SetPosition( 1 , _initialPosition );


        if(_isBirdLaunched && _thisRigidBody.velocity.magnitude < 0.07f)
            _timeSittingStill += Time.deltaTime;

        if( transform.position.y > 10   ||
            transform.position.y < -10  ||
            transform.position.x > 50   ||
            transform.position.x < -30  ||
            _timeSittingStill > timeToRespawn )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


    private void OnMouseDrag()
    {
        _thisLineRenderer.enabled = true;
        _thisSpriteRenderer.color = Color.yellow;

        //reset rotation
        transform.rotation = Quaternion.Euler(0,0,0);

        _directionToInitialPosition = _initialPosition - transform.position;


        _mousePositionToCamera = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePositionToCamera.z = 0;
        transform.position = _mousePositionToCamera;

    }

    private void OnMouseUp()
    {
        _thisLineRenderer.enabled = false;
        _thisSpriteRenderer.color = Color.white;


        _thisRigidBody.isKinematic = false;
        _thisRigidBody.AddForce(_directionToInitialPosition * launchPower);


        _isBirdLaunched = true;
    }

}
