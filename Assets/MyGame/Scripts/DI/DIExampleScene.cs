using System.Data.SqlTypes;
using UnityEngine;

namespace DI 
{
   
    public class DIExampleScene : MonoBehaviour
    {
        public void Init (DIContainer projectConteiner)
        {
            //var serviceWithoutTag = projectConteiner.Resolve<MyAwesomeProjectServise>();
            //var service1 = projectConteiner.Resolve<MyAwesomeProjectServise>("option1");
            //var service2 = projectConteiner.Resolve<MyAwesomeProjectServise>("option2");

            var sceneContainer = new DIContainer(projectConteiner);
            sceneContainer.RegisterSinglton(c => new MySceneService(c.Resolve<MyAwesomeProjectServise>()));
            sceneContainer.RegisterSinglton(_ => new MyAwesomeFactory());
            sceneContainer.RegisterInstance(new MyAwesomeObject("instance", 10));

            var objectsFactory = sceneContainer.Resolve<MyAwesomeFactory>();

            for (int i = 0; i < 3; i++)
            {
                var id = $"o{i}";
                var o = objectsFactory.CreateInstance(id, i);
                Debug.Log($"Object created with factory.\n {0}");
            }

            var instance = sceneContainer.Resolve<MyAwesomeObject>();
            Debug.Log($"Object instance.\n {instance}");

        }
    
    }

}

