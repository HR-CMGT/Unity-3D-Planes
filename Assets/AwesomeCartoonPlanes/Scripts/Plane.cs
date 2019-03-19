using UnityEngine;

public class Plane : MonoBehaviour {
    [SerializeField]
    private float _speed;

    [SerializeField]
    private GameObject _projectile;
	public GameObject prop;
	public GameObject propBlured;

    [SerializeField]
	private bool _engineOn;

    [SerializeField]
    private Transform _shotSpawn;
    [SerializeField]
    private float _fireRate;
    private float nextFire;

    [SerializeField]
    private float _turnSpeed;

    void Update () 
	{
		if (_engineOn) {
			prop.SetActive (false);
			propBlured.SetActive (true);
			propBlured.transform.Rotate (1000 * Time.deltaTime, 0, 0);
		} else {
			prop.SetActive (true);
			propBlured.SetActive (false);
		}

        if (Input.GetButton("Jump") && Time.time > nextFire)
        {
            nextFire = Time.time + _fireRate;
            Instantiate(_projectile, _shotSpawn.position, _shotSpawn.rotation);
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal    = Input.GetAxis("Horizontal");
        float moveVertical      = Input.GetAxis("Vertical");

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

    private void Fire()
    {
        GameObject rocketClone = Instantiate(
            _projectile,
            transform.position,
            new Quaternion(90, 0, 0, 0)) as GameObject;
    }
}