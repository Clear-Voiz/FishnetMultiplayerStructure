using FishNet.Object;
using UnityEngine;

public class Moving : NetworkBehaviour
{
    public float MoveSpeed = 5f;
    private CharacterController _characterController;
    private Animating _animating;
    private float rotateSpeed = 150f;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _animating = GetComponent<Animating>();
    }

    //[Client(RequireOwnership = true)]
    private void Update()
    {
        if (IsOwner)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            transform.Rotate(new Vector3(0f, horizontal * rotateSpeed * Time.deltaTime));
            Vector3 offset = new Vector3(0f, Physics.gravity.y, vertical) * (MoveSpeed * Time.deltaTime);
            offset = transform.TransformDirection(offset);
            _characterController.Move(offset);

            bool isMoving = (horizontal != 0f || vertical != 0f);
            _animating.SetMoving(isMoving);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _animating.Jump();
            }
        }
    }
}
