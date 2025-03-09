using UnityEngine;

public class BricksManager : MonoBehaviour
{
    [SerializeField] GameObject _brickPrefab;
    GameObject _currentBrick;
    float _currentY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentY = 0.0f;
        _currentBrick = Instantiate(_brickPrefab, new Vector3(0.0f, _currentY, 0.0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Bricks brick = _currentBrick.GetComponent<Bricks>();
            brick.IsPlaced = true;
            _currentY = _currentBrick.transform.position.y + brick.Grid.y;
            _currentBrick.GetComponent<Renderer>().material.shader = Shader.Find("Universal Render Pipeline/Lit");
            _currentBrick = Instantiate(_brickPrefab, new Vector3(_currentBrick.transform.position.x, _currentY, _currentBrick.transform.position.z), Quaternion.identity);
        }
    }
}
