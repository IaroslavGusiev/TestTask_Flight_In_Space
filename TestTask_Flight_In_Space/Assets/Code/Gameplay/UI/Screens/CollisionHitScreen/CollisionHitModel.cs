using Services.ScreenServiceSpace;

namespace Code.Gameplay.UI
{
    public class CollisionHitModel : BasePersistentModel<CollisionHitModel>
    {
        public ICollisionHitSystem CollisionHitSystem { get; private set; }

        public CollisionHitModel(ICollisionHitSystem collisionHitSystem) => 
            CollisionHitSystem = collisionHitSystem;
    }
}