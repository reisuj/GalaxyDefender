using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private float _fireRate = 0.25f;
    private float _nextFire = 0.0f;
    [SerializeField]
    private bool _tripleShotActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireRate;
            if (_tripleShotActive)
            {
                FireTripleShot();
            }
            else
            {
                FireLaser();
            }
        }
    }

    private void FireLaser()
    {        
        GameObject playerLaser = Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.25f, 0), Quaternion.identity);
        playerLaser.tag = "PlayerLaser";
    }

    private void FireTripleShot()
    {        
        GameObject playerLaser = Instantiate(_tripleShotPrefab, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
        playerLaser.tag = "PlayerLaser";
    }
}
