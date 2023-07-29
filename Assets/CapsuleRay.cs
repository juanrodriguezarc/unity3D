using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleRay : MonoBehaviour
{
    // Start is called before the first frame update
    Transform camera;
    [SerializeField]
    GameObject planet;

    Rigidbody _rb;
    [SerializeField]
    float _speed = 5;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        // camera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {



    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        // Gizmos.color = Color.blue;

        // Vector3 fwd = transform.position + transform.forward*10;


        // Gizmos.DrawLine(transform.position, fwd);

        // var x = new Vector3(1,2,3) + new Vector3(1,1,2);


        // Debug.Log(transform.position);
        // Debug.Log(transform.up*20);
        // // Debug.Log(x*2);

        // // Debug.Log(transform.TransformDirection(Vector3.down));


        // Gizmos.DrawLine(transform.position,transform.position + (transform.up*20));
    }

    // See Order of Execution for Event Functions for information on FixedUpdate() and Update() related to physics queries
    void FixedUpdate()
    {


        var move = _rb.transform.forward;

        if (Input.GetAxis("Horizontal") != 0)
            _rb.transform.position += _rb.transform.right * Input.GetAxis("Horizontal") * _speed;

        if (Input.GetAxis("Vertical") != 0)
            _rb.transform.position += _rb.transform.forward * Input.GetAxis("Vertical") * _speed;

        RaycastHit hit;
        if (Physics.Raycast(_rb.position, -_rb.transform.up, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(_rb.transform.position, -_rb.transform.up * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            var pos = _rb.transform.position;
            pos.y = hit.point.y + 1;
            _rb.transform.position = pos;
        }
        else
        {
            Debug.DrawRay(transform.position, -transform.up * 1000, Color.red);
            Debug.Log("Did not Hit");
        }


        // _rb.transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 250.0f * Time.fixedDeltaTime);

        // if(Input.GetKeyDown(KeyCode.Space))
        // _rb.transform.LookAt(planet.transform);

        transform.rotation = Quaternion.FromToRotation(Vector3.right*.25f, transform.forward);

        Debug.DrawRay(transform.position, transform.forward * 1000, Color.black);




    }
}
