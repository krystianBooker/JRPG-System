﻿using System;
using System.Collections;
using EventSystem.Models.interfaces;
using UnityEngine;
using XNode;

namespace EventSystem.Events
{
    public class AnimationExecution : IEventExecution
    {
        private AnimationNode _animationNode;
        private Animator _animator;

        public IEnumerator Execute(Node node)
        {
            _animationNode = node as AnimationNode;
            if (_animationNode != null)
            {
                //Get animator
                _animator = _animationNode.animationTarget.GetComponent<Animator>();
            
                //Start animation
                _animator.SetTrigger(_animationNode.animationTrigger);
                yield return null;
            }
            else
            {
                Debug.LogException(new Exception($"{nameof(AnimationExecution)}: Invalid setup on {nameof(AnimationNode)}."));
            }
        }

        public bool IsFinished()
        {
            return true;
            //Animation event :o
        }
    }
}