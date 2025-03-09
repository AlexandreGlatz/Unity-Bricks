using UnityEngine;

public class BricksManager : MonoBehaviour
{
    [SerializeField] GameObject _brickPrefab;
    [SerializeField] Mesh[] _meshes;

    Color[] _palette = { Color.white, Color.red, Color.blue, Color.green, Color.yellow };
    
    GameObject _currentBrick;
    float _currentY;
    int _colorIndex;
    int _meshIndex;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _colorIndex = 0;
        _meshIndex = 0;
        _currentY = 0.0f;
        _currentBrick = Instantiate(_brickPrefab, new Vector3(0.0f, _currentY, 0.0f), Quaternion.identity);
        _currentBrick.GetComponent<Bricks>().CurrentMesh = _meshes[0];
    }

    // Update is called once per frame
    void Update()
    {
        Bricks brick = _currentBrick.GetComponent<Bricks>();
        if (Input.GetKeyDown(KeyCode.Return))
        {
            brick.IsPlaced = true;

            Material material = _currentBrick.GetComponent<Renderer>().material;
            material.shader = Shader.Find("Universal Render Pipeline/Lit");
            material.SetColor("_Base Map", brick.CurrentColor);

            _currentY = _currentBrick.transform.position.y + brick.Grid.y;
            _currentBrick = Instantiate(_brickPrefab, new Vector3(_currentBrick.transform.position.x, _currentY, _currentBrick.transform.position.z), Quaternion.identity);
            _currentBrick.GetComponent<Bricks>().CurrentMesh = _meshes[0];
        }

        if(Input.GetKeyDown(KeyCode.I)) 
        {
            _colorIndex++;
            if (_colorIndex >= _palette.Length)
                _colorIndex = 0;

            brick.CurrentColor = _palette[_colorIndex];
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            _colorIndex--;
            if (_colorIndex < 0)
                _colorIndex = _palette.Length - 1;

            brick.CurrentColor = _palette[_colorIndex];
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            _meshIndex++;
            if (_meshIndex >= _meshes.Length)
                _meshIndex = 0;

            brick.CurrentMesh = _meshes[_meshIndex];
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            _meshIndex--;
            if (_meshIndex < 0)
                _meshIndex = _meshes.Length - 1;

            brick.CurrentMesh = _meshes[_meshIndex];
        }
    }
}
