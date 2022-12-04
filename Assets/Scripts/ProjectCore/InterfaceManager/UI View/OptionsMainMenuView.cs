using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectCore.InterfaceManger.UIView
{
    public class OptionsMainMenuView : MonoBehaviour
    {
        [SerializeField] private Button m_ButtonBack;
        public Button ButtonBack => m_ButtonBack;
    }
}
