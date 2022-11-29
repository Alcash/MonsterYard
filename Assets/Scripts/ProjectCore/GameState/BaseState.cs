using ProjectCore.InterfaceManger.UIView;
using ProjectCore.InterfaceManger;
using ProjectCore.StateManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data.SqlTypes;

namespace ProjectCore.StateManager
{
    public abstract class BaseState : IState
    {
        protected abstract string interfaceKey { get; }
        protected readonly GameManager gameStateManager;
        protected readonly InterfaceManager interfaceManager;        
        protected InterfaceWindow interfaceWindow;

        public BaseState(GameManager manager, InterfaceManager interfaceManager)
        {
            this.gameStateManager = manager;
            this.interfaceManager = interfaceManager;

        }        

        public abstract void StateEnd();

        public abstract void StateInit();

        public abstract void StateStart(IStateArgs stateArgs = null);

        protected bool LoadView<T>(out T interfaceView)
        {
            interfaceView = default(T);
            if (interfaceManager.LoadView(interfaceKey, out interfaceWindow))
            {
                interfaceView = interfaceWindow.GetComponent<T>();
                return true;
            }
            return false;
        }
    }
}
