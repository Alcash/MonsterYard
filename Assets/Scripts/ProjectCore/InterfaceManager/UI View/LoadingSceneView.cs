using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectCore.InterfaceManger.UIView
{
    public class LoadingSceneView : MonoBehaviour
    {
        [SerializeField] private Text m_TextStatus;
        public Text TextStatus => m_TextStatus;
        [SerializeField] private Slider m_SliderStatus;
        public Slider SliderStatus => m_SliderStatus;
    }
}
