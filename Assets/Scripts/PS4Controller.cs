using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PS4Controller : MonoBehaviour
{
    private Gamepad _gamepad;

    public Gamepad GameController
    {
        get => _gamepad;
        private set => _gamepad = value;
    }
    // Start is called before the first frame update
    void Start()
    {
        GameController = Gamepad.current;

        if (_gamepad == null)
        {
            Debug.Log("No Gamepad Connected!!");
            GameController = new Gamepad();
        }
    }

    public IEnumerator RumbleForSeconds(float seconds, float leftSpeed, float rightSpeed)
    {
        GameController.SetMotorSpeeds(leftSpeed, rightSpeed);

        yield return new WaitForSeconds(seconds);

        GameController.SetMotorSpeeds(0f, 0f);
    }

    public void Rumble(float leftSpeed, float rightSpeed)
    {
        StartCoroutine(RumbleForSeconds(.5f, leftSpeed, rightSpeed));
    }

    public void StopRumble()
    {
        StopCoroutine(nameof(RumbleForSeconds));
    }
}
