using System;

namespace Robot
{
    public class ED209
    {
        private IWeaponStore _weaponStore;

        public ED209 () {
        }

        public ED209(IWeaponStore weaponStore) {
            _weaponStore = weaponStore;
        }

        public Target SelectTarget(Target targets) {
            return Target.Humans;
        }

        public Weapon Fire() {
            var weaponFired = _weaponStore.GetIfAvailable(Weapon.Lazer);
            return weaponFired;
        }
    }

    [Flags()]
    public enum Target {
        Humans = 1,
        Animals = 2,
        Robots = 4
    }

    public enum Weapon {
        None,
        Lazer,
        Chainsaw
    }

    public interface IWeaponStore {
        Weapon GetIfAvailable(Weapon requested);
    }
}
