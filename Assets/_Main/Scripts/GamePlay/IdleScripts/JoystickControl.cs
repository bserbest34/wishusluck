using UnityEngine;

public class JoystickControl : MonoBehaviour
{
    FloatingJoystick floatingJoystick;
    CharacterController characterController;
    public float movSpeed, rotSpeed;

    private void Start()
    {
        floatingJoystick = GameObject.FindGameObjectWithTag("FloatingJoystick").GetComponent<FloatingJoystick>();
        characterController = GetComponent<CharacterController>();
    }
   
    public void Update()
    {
        SetPosition();
        SetRotation();
        SetAnimation();
    }

    void SetRotation()
    {
        if (floatingJoystick.Vertical == 0 && floatingJoystick.Horizontal == 0)
            return;
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(floatingJoystick.Horizontal, 0, floatingJoystick.Vertical));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
    }

    void SetPosition()
    {
        Vector3 direction = Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;
        direction.y = 0;
        characterController.Move(direction * movSpeed * Time.deltaTime);
    }

    void SetAnimation()
    {
        if(floatingJoystick.Vertical == 0 && floatingJoystick.Horizontal == 0) {
            GetComponent<Animator>().SetBool("Walk", false);
            GetComponent<Animator>().SetBool("Idle", true);
        } else {
            GetComponent<Animator>().SetBool("Idle", false);
            GetComponent<Animator>().SetBool("Walk", true);
        }
    }
}