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
        private int _bullets;

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
            _bullets = bullets;
        }

        public void Fire(Player player)
        {
            if (player is null)
                throw new ArgumentNullException(nameof(player));

            player.TakeDamage(_damage);
            _bullets--;
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
        private Weapon _weapon = new Weapon(1, 3);

        private void OnSeePlayer(Player player)
        {
            _weapon.Fire(player);
        }
    }
}
