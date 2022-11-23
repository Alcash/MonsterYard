
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ProjectCore.InterfaceManger
{
    public class InterfaceManager : MonoBehaviour
    {
        [SerializeField] private InterfaceData m_InterfaceData;

        private Dictionary<string, InterfaceWindow> m_InterfaceViews = new Dictionary<string, InterfaceWindow>();
        private List<string> _windowsList = new List<string>();

        private void Awake()
        {                
            foreach (var window in m_InterfaceData.InterfaceWindows)
            {
                m_InterfaceViews.Add(window.InterfaceKey, window);
                window.InitView(this);
            }    
        }       

        public bool LoadView(string key, out InterfaceWindow interfaceWindow)
        {
            interfaceWindow = null;
            if (m_InterfaceViews.ContainsKey(key) == false)
                return false;

           
            interfaceWindow = m_InterfaceViews[key];
            return true;
        }

        public void OpenView(string key)
        {
            foreach (var view in m_InterfaceViews)
            {
                m_InterfaceViews[view.Key].SetActive(key == view.Key);
            }
            _windowsList.Add(key);
        }

        public void ClosePartView(string key)
        {            
            _windowsList.Remove(key);            
            m_InterfaceViews[key].SetActive(false);           
        }

        public void CloseLastView()
        {
            var lastKey = _windowsList.Last();
            _windowsList.Remove(lastKey);

            foreach (var view in m_InterfaceViews)
            {
                m_InterfaceViews[view.Key].SetActive(_windowsList.Last() == view.Key);
            }
        }
    }
}