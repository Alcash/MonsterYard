using ProjectCore.InterfaceManger;
using ProjectCore.InterfaceManger.UIView;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectCore.StateManager
{
    public class GameState : BaseState
    {
        private readonly string _interfaceKey = "Screen.GameState";
        protected override string interfaceKey => _interfaceKey;

        private GameStateView _view;

        public GameState(GameManager manager, InterfaceManager interfaceManager) : base(manager, interfaceManager)
        {
        }

        public override void StateEnd()
        {
            interfaceManager.CloseLastView();
        }

        public override void StateInit()
        {
            if(LoadView(out _view))
            {
                _view.ButtonPause.onClick.AddListener(OnPauseCicked);
            }
        }

        private void OnPauseCicked()
        {
            gameStateManager.StartState(typeof(GamePauseState));
        }

        public override void StateStart(IStateArgs stateArgs = null)
        {
            interfaceManager.OpenView(interfaceKey);
        }

       
    }
}
