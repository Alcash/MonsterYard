using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectCore.InterfaceManger
{
    public class InterfaceWindow : MonoBehaviour
    {
        [SerializeField] private string m_InterfaceKey;
        public string InterfaceKey => m_InterfaceKey;       

        private InterfaceManager _interfaceManager;

        public void InitView(InterfaceManager interfaceManager)
        {
            _interfaceManager = interfaceManager;
        } 

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }


        public void SetActive(bool enable)
        {
            gameObject.SetActive(enable);
        }
    }
}
