﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
     Vector3 _InitialPosition;
    private bool _birdWasLaunched;

    [SerializeField] private float _launchPower= 500;
    private float _timeSittingAround;

    private void Awake()
    {
        _InitialPosition = transform.position;
    }
    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(0, _InitialPosition);
        GetComponent<LineRenderer>().SetPosition(1, transform.position);

        if (_birdWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _timeSittingAround += Time.deltaTime;
        }
        if (transform.position.y > 7 || transform.position.y < -6.18 || transform.position.x < -15.17 || transform.position.x > 15.17 || _timeSittingAround > 3 )
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
         }
        
    }
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;

    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 directionToInitialPosition = _InitialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower );
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdWasLaunched = true;
        GetComponent<LineRenderer>().enabled = false;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y) ;
    }
}
