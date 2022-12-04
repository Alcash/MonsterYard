using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectCore.InterfaceManger.UIView
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button m_StartGameButton;
        public Button StartGameButton => m_StartGameButton;

        [SerializeField] private Button m_ExitGameButton;
        public Button ExitGameButton => m_ExitGameButton;

        [SerializeField] private Button m_SettingButton;
        public Button SettingButton => m_SettingButton;
    }
}
