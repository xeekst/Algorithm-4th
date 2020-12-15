using System;

namespace CollisionSimulation
{
    public class Particle
    {
        private double _rx;
        private double _ru;
        private double _vx;
        private double _vy;
        private double _s;
        private double _mass;
        private int _count = 0;

        public Particle() { }
        public Particle(double rx, double ru, double vx, double vy, double s, double mass)
        {
            _rx = rx;
            _ru = ru;
            _vx = vx;
            _vy = vy;
            _s = s;
            _mass = mass;
        }

        public void Draw()
        {
            throw new NotImplementedException();
        }

        public void Move(double dt)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            return _count;
        }

        // 距离粒子b碰撞需要的时间
        public double TimeToHit(Particle b)
        {
            throw new NotImplementedException();
        }

        //距离该粒子和垂直的墙体碰撞所需的时间
        public double TimeToHitVerticalWall()
        {
            throw new NotImplementedException();
        }

        //距离该粒子和水平的墙体碰撞所需的时间
        public double TimeToHItHorizontalWall()
        {
            throw new NotImplementedException();
        }

        // 碰撞粒子后该粒子的速度
        public double BounceOff(Particle b)
        {
            throw new NotImplementedException();
        }

        //碰撞水平墙壁后的该粒子速度
        public double BounceOffHorizontalWall()
        {
            throw new NotImplementedException();
        }

        //碰撞垂直墙体后的该粒子速度
        public double BounceOffVerticalWall()
        {
            throw new NotImplementedException();
        }
    }
}