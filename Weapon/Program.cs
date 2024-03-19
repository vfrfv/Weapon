using System;

namespace Weapon
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Weapon
    {
        private readonly int _damage;

        public Weapon(int damage, int bullets)
        {
            if (damage < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(damage));
            }

            if (bullets <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bullets));
            }

            _damage = damage;
            Bullets = bullets;
        }

        public int Bullets { get  ; private set; }

        public void Fire(Player player)
        {
            if (player is null)
                throw new ArgumentNullException(nameof(player));

            if (Bullets > 0)
            {
                Bullets--;
                player.TakeDamage(_damage);
            }
        }
    }

    class Player
    {
        private int _health;

        public void TakeDamage(int damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            _health -= damage;

            if (_health < 0)
                _health = 0;
        }
    }

    class Bot
    {
        private Weapon _weapon;

        public Bot(Weapon weapon)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        public bool HasBullets => _weapon.Bullets > 0;

        public void OnSeePlayer(Player player)
        {
            if (player is null)
                throw new ArgumentNullException(nameof(player));

            if (HasBullets)
            {
                _weapon.Fire(player);
            }
        }
    }
}
