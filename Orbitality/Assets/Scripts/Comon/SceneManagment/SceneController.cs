using UnityEngine.SceneManagement;

namespace Comon.SceneManagment
{
    public static class SceneController
    {
        public static void LoadScene(Scene scene)
        {
            SceneManager.LoadScene((int) scene);
        }
    }
}