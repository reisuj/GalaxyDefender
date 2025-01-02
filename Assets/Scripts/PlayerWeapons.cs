using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private GameObject _playerLaser;
    [SerializeField]
    private float _fireRate = 0.25f;
    private float _nextFire = 0.0f;
    [SerializeField]
    private bool _isTripleShotActive = false;
    [SerializeField]
    private float _laserOffset = 1.25f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireRate;
            if (_isTripleShotActive)
            {
                FireTripleShot();
            }
            else
            {
                FireLaser();
            }
            _playerLaser.tag = "PlayerLaser";
        }
    }

    private void FireLaser()
    {        
        _playerLaser = Instantiate(_laserPrefab, transform.position + new Vector3(0, _laserOffset, 0), Quaternion.identity);
    }

    private void FireTripleShot()
    {        
        _playerLaser = Instantiate(_tripleShotPrefab, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
    }
}
