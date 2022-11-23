using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectCore.InterfaceManger.UIView
{
    public class MainMenuView : MonoBehaviour
    {
        public event Action StartGameClicked;
        public event Action ExitGameClicked;
        public event Action SettingClicked;


        [SerializeField] private Button m_StartGameButton;
        [SerializeField] private Button m_ExitGameButton;
        [SerializeField] private Button m_SettingButton;
    }
}
