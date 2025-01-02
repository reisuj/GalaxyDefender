using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;    
    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private SpawnManager _spawnManager;
    private float _horizontalInput;
    private float _verticalInput;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();        
    }

    void PlayerMovement() 
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(_horizontalInput, _verticalInput, 0).normalized;
        transform.Translate(direction * Time.deltaTime * _speed);

        //Constrain the player's movement on the y-axis
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4, 1), 0);

        //Wrap the player's movement on the x-axis
        if (transform.position.x > 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }

    public void Damage()
    {
        _lives--;
        if (_lives == 0)
        {            
            if (_spawnManager != null)
            {
                _spawnManager.GetComponent<SpawnManager>().PlayerIsDead();
            }
            Destroy(this.gameObject);
        }
    }
}
