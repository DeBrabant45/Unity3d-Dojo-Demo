using UnityEngine;

namespace AD.Animation
{
    public class HumanoidAnimations : MonoBehaviour
    {
        private Animator _animator;
        private IAnimatorService _animatorService;

        public IAnimatorService AnimatorService { get => _animatorService; set => _animatorService = value; }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            if (_animatorService == null)
            {
                _animatorService = new AnimatorService(_animator);
            }
        }

        private void OnAnimatorMove()
        {
            if (_animatorService.GetAnimationBool("IsUsingRootMotion") != false)
            {
                _animatorService.GetAnimationDeltaPosition();
            }
        }
    }
}