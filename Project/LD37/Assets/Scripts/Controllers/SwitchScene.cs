using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Controllers
{
    class SwitchScene : MonoBehaviour
    {
        public void Switch(int index)
        {
            SceneManager.LoadScene(1);
        }
    }
}
