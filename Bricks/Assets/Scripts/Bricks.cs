using UnityEngine;
using UnityEngine.UIElements;
using static System.Net.WebRequestMethods;

public class Bricks : MonoBehaviour
{
    [SerializeField] GameObject _gameobject;
    [SerializeField] Vector3 _grid;
    Color _currentColor;
    Material _material;
    bool _isPlaced;
    public bool IsPlaced
    {
        get { return _isPlaced; } 
        set { _isPlaced = value; } 
    }

    public Vector3 Grid
    {
        get { return _grid; }
        set { _grid = value; }
    }

    public Color CurrentColor
    {
        get { return _currentColor; }
        set { _currentColor = value; }
    }

    void Start()
    {
        _currentColor = Color.white;
        _isPlaced = false;
        _material = _gameobject.GetComponent<Renderer>().material;
        _material.shader = Shader.Find("Shader Graphs/Unplaced Brick");
    }

    // Update is called once per frame
    void Update()
    {
        if(_isPlaced == true) { return; }

        _material.SetColor("_BaseColor", _currentColor);

        if (Input.GetKeyDown(KeyCode.D))
        {
            _gameobject.transform.position += new Vector3(_grid.x, 0.0f, 0.0f);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _gameobject.transform.position += new Vector3(- _grid.x, 0.0f, 0.0f);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _gameobject.transform.position += new Vector3(0.0f, 0.0f, _grid.z);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            _gameobject.transform.position += new Vector3(0.0f, 0.0f, - _grid.z);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _gameobject.transform.position += new Vector3(0.0f, _grid.y, 0.0f);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _gameobject.transform.position += new Vector3(0.0f, - _grid.y, 0.0f);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            _gameobject.transform.Rotate(0.0f,90.0f,0.0f, Space.World);
        }
    }
}
