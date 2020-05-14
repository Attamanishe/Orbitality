namespace Game.Physics
{
    public class PhysicStaticObject : PhysicObject
    {
        public virtual void Start()
        {
            PhysicsController.Instance.AddStatic(this);
        }
        
        public virtual void OnDestroy()
        {
            PhysicsController.Instance?.RemoveStatic(this);
        }
    }
}