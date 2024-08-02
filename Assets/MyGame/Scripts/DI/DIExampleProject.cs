using UnityEngine;

namespace DI
{
    public class MyAwesomeProjectServise
    {

    }

    public class MySceneService
    {
        private readonly MyAwesomeProjectServise _myAwesomeProjectServise;
        public MySceneService (MyAwesomeProjectServise myAwesomeProjectServise)
        {
            _myAwesomeProjectServise = myAwesomeProjectServise;
        }
    }

    public class MyAwesomeFactory
    {
        public MyAwesomeObject CreateInstance(string id, int par1)
        {
            return new MyAwesomeObject (id, par1);
        }
    }
    public class MyAwesomeObject
    {
        public readonly string _id;
        public readonly int _par1;
        public MyAwesomeObject(string id, int par1)
        {
            _id = id;
            _par1 = par1;
        }
    }
    public class DIExampleProject : MonoBehaviour
    {
        private void Awake()
        {
                var projectContainer = new DIContainer ();
            projectContainer.RegisterSinglton(_=> new MyAwesomeProjectServise());
            projectContainer.RegisterSinglton("option1", _ => new MyAwesomeProjectServise());
            projectContainer.RegisterSinglton("option2", _ => new MyAwesomeProjectServise());

            var sceneRoot = FindAnyObjectByType<DIExampleScene>();
            sceneRoot.Init(projectContainer);
        }
    }

}