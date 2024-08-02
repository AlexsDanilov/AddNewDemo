using MyGame.Scripts.Utils;
using UnityEngine;

namespace MyGame.Scripts.Game.GameRoot
{

    public class GameEntryPoint
    {
        private static GameEntryPoint _instance;

        private Coroutines _coroutines;
        private UIRootView _uiRoot;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]

        public static void AutoStartGame()
        {
            Application.targetFrameRate = 60;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            _instance = new GameEntryPoint();
            _instance.RunGame();
        }

        private GameEntryPoint() 
        {
            _coroutines = new GameObject("[COROUTINES]").AddComponent<Coroutines>();
            Object.DontDestroyOnLoad( _coroutines.gameObject );

            var prefabUIRoot = Resources.Load<UIRootView>("[UIRoot]");
            _uiRoot = Object.Instantiate(prefabUIRoot);
            Object.DontDestroyOnLoad(_uiRoot.gameObject);

        }

        private void RunGame()
        {

        }

    }


}