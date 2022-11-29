using ProjectCore.InterfaceManger.UIView;
using ProjectCore.InterfaceManger;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ProjectCore.StateManager
{
    public class OptionsMainMenuState : BaseState, IState
    {
       
        private readonly string _interfaceKey = "Screen.MainMenu.Options";
        protected override string interfaceKey => _interfaceKey;
        
        private OptionsMainMenuView _optionsView;

        public OptionsMainMenuState(GameManager manager, InterfaceManager interfaceManager) : base(manager, interfaceManager)
        {
        }

        public override void StateEnd()
        {            
            interfaceManager.CloseLastView();
        }

        public override void StateInit()
        {
            if(LoadView(out _optionsView))
            {
                _optionsView.ButtonBack.onClick.AddListener(OnBackButton);
            }
        }

        private void OnBackButton()
        {
            gameStateManager.StartState(typeof(MainMenuState));
        }

        public override void StateStart(IStateArgs stateArgs = null)
        {
            interfaceManager.OpenView(_interfaceKey);
        }
    }
}
