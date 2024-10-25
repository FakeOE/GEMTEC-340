using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    private Vector2 _input;

    private List<Transform> _children;
    public Transform childrenPrefab;

    private void Start()
    {
        _children = new List<Transform>();
        _children.Add(transform);
    }

    private void Update()
    {
        if (_direction.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
                _input = Vector2.up;
            } else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
                _input = Vector2.down;
            }
        }
        else if (_direction.y != 0f)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
                _input = Vector2.right;
            } else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
                _input = Vector2.left;
            }
        }
    }
    private void FixedUpdate()
    {
        if (_input != Vector2.zero)
        {
            _direction = _input;
        }
        for (int i = _children.Count - 1; i > 0; i--)
        {
            _children[i].position = _children[i - 1].position;
        }
            
        transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f);
        

    }

    private void Grow()
    {
        Transform children = Instantiate(childrenPrefab);
        children.position = _children[_children.Count - 1].position;
        _children.Add(children);
    }

    private void ResetState()
    {
        for (int i = 1; i < _children.Count; i++)
        {
            Destroy(_children[i].gameObject);
        }
        _children.Clear();
        _children.Add(transform);
        transform.position = Vector3.zero;
    }
    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Apple"))
        {
            Grow();
            ScoreManager.instance.AddScore();
        }
        else if (player.CompareTag("Wall"))
            ResetState();
    }

    /*public bool Occupy(float x, float y)
    {
        foreach (Transform child in _children)
        {
            if (child.position.x == x && child.position.y == y)
            {
                return true;
            }
        }
        return false;
    }*/
}

