using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed;
    public float rotateSpeed;

    private float _hInput;
    private float _vInput;
    private Rigidbody _rb;

    public float jumpVelocity = 5f;
    private bool _isJumping;

    public float distanceToGround = 0.1f;
    public LayerMask groundLayer;
    private CapsuleCollider _col;

    public GameObject bullet;
    public float bulletSpeed;
    private bool _isShooting;

    private GameBehavior _gameManager;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
    }

    void Update()
    {
        _hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        _vInput = Input.GetAxis("Vertical") * moveSpeed;

        _isJumping |= Input.GetKeyDown(KeyCode.J);
        _isShooting |= Input.GetKeyDown(KeyCode.Space);

        //this.transform.Translate(Vector3.forward * _vInput  * Time.deltaTime);
        //this.transform.Rotate(Vector3.up * _hInput  * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        //Salto
        if (IsGrounded() && _isJumping)
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }

        _isJumping = false;

        //Disparo
        if (_isShooting)
        {
            GameObject newBullet = Instantiate(bullet, this.transform.position + this.transform.forward * 1, transform.rotation);

            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();

            bulletRB.velocity = transform.forward * bulletSpeed;
        }


        _isShooting = false;

        //Movimiento
        Vector3 rotation = Vector3.up * _hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);

        _rb.MovePosition(this.transform.position + this.transform.forward * _vInput * Time.fixedDeltaTime);
    }

    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);

        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);

        return grounded;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            _gameManager.HP--;
        }
    }
}
