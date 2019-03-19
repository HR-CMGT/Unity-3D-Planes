using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{

    // Add private bool for engine on
    [SerializeField]
    private bool _engineOn;

    [SerializeField]
    private GameObject _prop;
    [SerializeField]
    private GameObject _propBlured;
    [SerializeField]
    private float _turnSpeed;
    [SerializeField]
    private int _speed;

    private float _nextFire;
    [SerializeField]
    private float _fireRate;
    [SerializeField]
    private GameObject _projectile;
    [SerializeField]
    private Transform _shotSpawn;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_engineOn)
        {
            _prop.SetActive(false);
            _propBlured.SetActive(true);
            _propBlured.transform.Rotate(1000 * Time.deltaTime, 0, 0);
        }
        else
        {
            _prop.SetActive(true);
            _propBlured.SetActive(false);
        }

        // Time.time, This is the time in seconds since the start of the game.
        if (Input.GetButton("Jump") && Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireRate;
            Instantiate(_projectile, _shotSpawn.position, _shotSpawn.rotation);
        }

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if (_engineOn)
        {
            GetComponent<Rigidbody>().velocity = transform.up * -_speed;

            transform.Rotate(
                new Vector3(
                    moveVertical * _turnSpeed,
                    moveHorizontal * _turnSpeed,
                    moveHorizontal * 0.3f * _turnSpeed),
                Space.Self);
        }

    }
}
