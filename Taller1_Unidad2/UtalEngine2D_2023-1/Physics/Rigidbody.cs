using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasDrawing.UtalEngine2D_2023_1.Physics
{
    public class Rigidbody
    {
        public Transform transform;
        public List<Collider> colliders = new List<Collider>();
        public float mass;
        public Vector2 Velocity;

        public delegate void CollisionDelegate(Object o);
        public CollisionDelegate OnCollision;
        public delegate Object GetOnCollisionObjectDelegate();
        public GetOnCollisionObjectDelegate GetOnCollisionObject;

        public Rigidbody()
        {
            PhysicsEngine.allRigidbodies.Add(this);
        }
        public void CreateCircleCollider(float radius)
        {
            colliders.Add(new CircleCollider(this, radius));
        }
        public bool CheckCollision(Rigidbody otherRigid)
        {
            foreach(Collider myC in colliders)
            {
                foreach(Collider otherC in otherRigid.colliders)
                {
                    if (myC.CheckCollision(otherC))
                    {
                        if (OnCollision != null && otherRigid.GetOnCollisionObject != null)
                        {
                            OnCollision(otherRigid.GetOnCollisionObject);                            
                        }
                        if(GetOnCollisionObject != null && otherRigid.OnCollision != null)
                        {
                            otherRigid.OnCollision(GetOnCollisionObject);
                        }
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
