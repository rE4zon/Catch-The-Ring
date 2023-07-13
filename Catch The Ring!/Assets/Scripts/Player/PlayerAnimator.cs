using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator Animator;
    [SerializeField] private PlayerMovement PlayerMovement;

    private void Awake()
    {
        PlayerMovement.Jumped += Jump;
    }

    private void OnDestroy()
    {
        PlayerMovement.Jumped -= Jump;
    }
    private void Jump()
    {
        Animator.SetTrigger("IsJumping");
    }

    private void Update()
    {
        Animator.SetFloat("Speed", PlayerMovement.Speed);
    }
}
