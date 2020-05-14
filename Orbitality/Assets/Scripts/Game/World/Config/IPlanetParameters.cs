namespace Game.World.Config
{
    public interface IPlanetParameters
    {
        //used for save/load process
        int Id { get; }
        float GetHealth();
        float GetSpeed();
        void SetSpeed(float speed);
        void SetHealth(float health);
        float GetLifeTime(); 
        void SetLifeTime(float time);
    }
}