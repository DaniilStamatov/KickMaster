using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class ContentContainer : MonoBehaviour
    {
        [SerializeField] private GameObject _menu;
        [SerializeField] private Button _continueButton;

        private Hero _hero;
        private void Start()
        {
           
            _hero = FindObjectOfType<Hero>();
            _hero.OnMenu += LoadMenu;
            Time.timeScale = 0;
            _menu.SetActive(true);
            _continueButton.interactable = false;

            //UpdateHealth();
        }

        public void Continue()
        {
            _menu.SetActive(false);
            Time.timeScale = 1;
        }

        public void LoadMenu()
        {
            _menu.SetActive(true);
            _continueButton.interactable = true;
            Time.timeScale = 0;
        }

        public void Reload()
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            Time.timeScale = 1;
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void BeginNewGame()
        {
            _menu.SetActive(false);
            Time.timeScale = 1;
        }

    }
}
