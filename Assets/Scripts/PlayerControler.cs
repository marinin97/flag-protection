using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform FirePoint;
    public float BulletSpeed;

    private Camera _camera;
    private GameObject _bulletInstance;


    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            _bulletInstance = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
            Vector3 direction = (hit.point - FirePoint.position).normalized;
            _bulletInstance.GetComponent<Rigidbody>().velocity = direction * BulletSpeed;
        }     
    }
    
}
