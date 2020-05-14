using UnityEngine.SceneManagement;

namespace Common.SceneManagment
{
    public static class SceneController
    {
        public static void LoadScene(Scene scene)
        {
            SceneManager.LoadScene((int) scene);
        }
    }
}