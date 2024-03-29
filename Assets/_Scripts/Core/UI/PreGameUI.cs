using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace GameDev.Core
{
    public class PreGameUI : MonoBehaviour
    {
        [SerializeField]
        private GameObject InGameUI, GamePauseUI, FoodCardUI;

        [SerializeField]
        private Button PlayButton;
        private int timeSpeed;


        // private void Awake() => GameManager.OnBeforeStateChanged += OnStateChanged;

        // private void OnDestroy() => GameManager.OnBeforeStateChanged -= OnStateChanged;


        // Start is called before the first frame update
        void Start()
        {
            timeSpeed = 1;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown("escape"))
            {
                PauseGameAndShowUI(GamePauseUI);
            }
        }

        // private void OnStateChanged(GameState newState)
        // {
        //     if (newState == GameState.Win) PauseGameAndShowUI(GameWinUI);
        //     if (newState == GameState.Lose) PauseGameAndShowUI(GameLoseUI);
        //     if (newState == GameState.Pause) PauseGameAndShowUI(GamePauseUI);
        //     if (newState == GameState.InGame) BackToGame();
        // }

        // public void Pause()
        // {
        //     GameManager.Instance.ChangeState(GameState.Pause);
        // }

        // public void SpeedChange()
        // {
        //     switch (timeSpeed)
        //     {
        //         case 1:
        //             Time.timeScale = 2;
        //             timeSpeed = 2;
        //             break;

        //         case 2:
        //             Time.timeScale = 1;
        //             timeSpeed = 1;
        //             break;

        //         default:
        //             Time.timeScale = 1;
        //             timeSpeed = 1;
        //             break;
        //     }
        // }


        public void HideFoodCard()
        {
            FoodCardUI.SetActive(false);
        }

        public void ShowFoodCard(ScriptableHero hero)
        {
            Transform buttonTransform = EventSystem.current.currentSelectedGameObject.transform;
            string foodName = buttonTransform.parent.Find("Food Name").GetComponent<Text>().text;
            Debug.Log(foodName);

            FoodCardUI.transform.Find("Profile").GetComponent<Image>().sprite = hero.MenuSprite;
            FoodCardUI.transform.Find("Calorie").GetComponent<Text>().text = hero.calorieValue.ToString();
            FoodCardUI.transform.Find("Damage").GetComponent<Text>().text
                 = hero.BaseStats.AttackPower.ToString();
            FoodCardUI.transform.Find("MaxShots").GetComponent<Text>().text = hero.maxShots.ToString();
            FoodCardUI.SetActive(true);
        }

        public void Resume()
        {
            GamePauseUI.SetActive(false);
            Time.timeScale = 1;
            EnableMainGameUIButtons();
        }

        public void MainMenu()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("MainMenu");
        }

        private void PauseGameAndShowUI(GameObject UI)
        {
            Time.timeScale = 0;
            UI.SetActive(true);
            DisableMainGameUIButtons();
        }

        private void DisableMainGameUIButtons()
        {
            PlayButton.interactable = false;
        }

        private void EnableMainGameUIButtons()
        {
            PlayButton.interactable = true;
        }
    }
}
