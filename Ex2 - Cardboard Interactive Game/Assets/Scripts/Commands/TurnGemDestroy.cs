using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViewModel;

namespace Commands
{
    public class TurnGemDestroy : ICommand
    {
        private Gem gem;
        private GameData gameData;

        public TurnGemDestroy(Gem gem, GameData gameData)
        {
            this.gem = gem;
            this.gameData = gameData;
        }

        public void Execute()
        {
            if(gem.destroyByUser)
            {
                Debug.Log($"[TurnGemDestroy] Gem {gem.gemData.gemName} has been destroyed by the user.");
                gameData.OnDestroy.OnNext(gem);
                gem.gemData.OnDestroy.OnNext(gem);
                gameData.currentGemInScreen.Value--;
            } 
            else 
            {
                Debug.Log($"[TurnGemDestroy] Gem {gem.gemData.gemName} has been destroyed by the ground.");
                gameData.OnDestroy.OnNext(gem);
                gem.gemData.OnDestroy.OnNext(gem);
                gameData.currentGemInScreen.Value--;
            }
        }
    }
}
