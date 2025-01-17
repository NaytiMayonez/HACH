using UnityEngine;
using System.Collections;

public class TurningCarOver : MonoBehaviour
{
    public float offset = 1;
    public float delay = 1;

    private bool _canPressKey = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && _canPressKey)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            StartCoroutine("WaitForKeyPress");
        }
    }

    IEnumerator WaitForKeyPress()
    {
        _canPressKey = false;
        yield return new WaitForSeconds(delay);
        _canPressKey = true;
    }
}