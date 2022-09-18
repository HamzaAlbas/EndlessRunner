using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
{
    [SerializeField] private float untilNextAnim;
    [SerializeField] private int numberOfAnims;
    private bool _isAnimating;
    private float _idleTime;
    private int _animation;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ResetIdle();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (! _isAnimating)
        {
            _idleTime += Time.deltaTime;
            
            if (_idleTime > untilNextAnim && stateInfo.normalizedTime % 1 < 0.02f)
            {
                _isAnimating = true;
                _animation = Random.Range(1, numberOfAnims + 1);
                _animation = _animation * 2 - 1;
                
                animator.SetFloat("IdleAnimations", _animation - 1);
            }
        }    
        else if (stateInfo.normalizedTime % 1 > 0.98)
        {
            ResetIdle();
        }
        
        animator.SetFloat("IdleAnimations", _animation, 0.2f, Time.deltaTime);
    }

    private void ResetIdle()
    {
        if (_isAnimating)
        {
            _animation--;
        }
        _isAnimating = false;
        _idleTime = 0;
    }
}
