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
        private int _damage;
        private int _bullets;

        public void Fire(Player player)
        {
            player.TakeDamage(_damage);
            _bullets --;
        }
    }

    class Player
    {
        private int _health;

        public void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                return;
            }

            _health -= damage;

            if (_health < 0)
            {
                _health = 0;
            }
        }
    }

    class Bot
    {
        private Weapon _weapon;

        private void OnSeePlayer(Player player)
        {
            _weapon.Fire(player);
        }
    }
}
