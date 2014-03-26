using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Robot;
using System.Collections.Generic;
using Moq;

namespace CSharpTests
{
    [TestFixture]
    public class RobotTests
    {



        [Test]
        public void SelectTarget_HumansAvailable_SelectHumans() {
            //arrange
            var robotUnderTest = new ED209();

            // act
            var result = robotUnderTest.SelectTarget(Target.Animals | Target.Humans);

            // assert
            Assert.AreEqual(Target.Humans, result);
        }












        [Test]
        public void WhenHumansAreAvailableTheyAlwaysGetTargeted() {

            var result = new ED209().SelectTarget(Target.Animals | Target.Humans);

            Assert.AreEqual(Target.Humans, result);
        }














        [Test]
        public void when_humans_are_available_they_always_get_targeted() {

            var result = new ED209().SelectTarget(Target.Animals | Target.Humans);

            Assert.That(result, Is.EqualTo(Target.Humans));
        }
















        [Test]
        public void some_things_still_not_really_readable_or_consistent() {

            Assert.AreEqual(10.1, 10.11, 0.01);

            Assert.Contains(2, new List<int> { 1, 2, 3 });

            StringAssert.StartsWith("sh", "ships");
        }














        [Test]
        public void Mocking_works_OK_with_Moq_etc() {

            // arrange
            var fakeWeaponStore = new Mock<IWeaponStore>();
            fakeWeaponStore.Setup(ws => ws.GetIfAvailable(It.IsAny<Weapon>())).Returns(Weapon.Chainsaw);
            var robot = new ED209(fakeWeaponStore.Object);

            // act
            robot.Fire();

            // assert
            fakeWeaponStore.Verify( r => r.GetIfAvailable(It.IsAny<Weapon>()));
        }












        [Test]
        public void Mocking_without_a_famework_is_a_bit_heavyweight() {

            // arrange
            var fakeWeaponStore = new MockWeaponStore();
            fakeWeaponStore.weaponToReturn = Weapon.Lazer;
            var robot = new ED209(fakeWeaponStore);

            // act
            var result = robot.Fire();

            // assert
            Assert.That(result, Is.EqualTo(Weapon.Lazer));
        }
    }













    internal class MockWeaponStore : IWeaponStore {

        internal Weapon weaponToReturn;

        public Weapon GetIfAvailable(Weapon requested) {
            return weaponToReturn;
        }
    }

}
