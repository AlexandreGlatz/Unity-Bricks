using UnityEngine;

public class BricksManager : MonoBehaviour
{
    [SerializeField] GameObject _brickPrefab;
    GameObject _currentBrick;
    float _currentY;
    Color[] _palette = { Color.white, Color.red, Color.blue, Color.green, Color.yellow };
    int _index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _index = 0;
        _currentY = 0.0f;
        _currentBrick = Instantiate(_brickPrefab, new Vector3(0.0f, _currentY, 0.0f), Quaternion.identity);
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
        }

        if(Input.GetKeyDown(KeyCode.I)) 
        {
            _index++;
            if (_index >= _palette.Length)
                _index = 0;

            brick.CurrentColor = _palette[_index];
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            _index--;
            if (_index < 0)
                _index = _palette.Length - 1;

            brick.CurrentColor = _palette[_index];
        }
    }
}
