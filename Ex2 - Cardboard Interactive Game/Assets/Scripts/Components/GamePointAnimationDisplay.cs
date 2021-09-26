using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViewModel;
using UniRx;
using TMPro;

namespace Components
{
    public class GamePointAnimationDisplay : MonoBehaviour
    {
        public Animator animator;
        public TextMeshProUGUI pointerLabel;
        public GameData gameData;

        void Start()
        {
            gameData.OnDestroy
                .Subscribe(DisplayAnimation)
                .AddTo(this);
        }
        
        private void DisplayAnimation(Gem gem)
        {
            if(gem.destroyByUser && gem.gemData.gemPoint > 0)
            {
                pointerLabel.text = $"+{Mathf.Abs(gem.gemData.gemPoint)}";
            }
            else
            {
                if(gem.gemData.gemPoint > 0)
                {
                    pointerLabel.text = $"-{Mathf.Abs(gem.gemData.gemPoint)}";
                }
            }
            animator.SetTrigger("Pointer");
        }
    }
}
