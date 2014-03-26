module RobotTests.``some tests``

open Xunit
open FsUnit.Xunit
open Foq
open Robot



[<Fact>] 
let ``When humans are available, they always get targeted`` () =
    ()










[<Fact>] 
let ``Who's up for writing some F#?  Everyone?!  Sweet!`` () =
    ()











[<Fact>] 
let ``Check my tests can be written most fluently, with minimal syntax`` () =

    let result = ED209().SelectTarget(Target.Animals ||| Target.Humans)

    result |> should equal Target.Humans












[<Fact>] 
let ``One-line test, perhaps?`` () =

    ED209().SelectTarget(Target.Animals ||| Target.Humans) |> should equal Target.Humans









[<Fact>] 
let ``most things are pretty readable and consistent with fsUnit`` () =

    10.1 |> should (equalWithin 0.1) 10.11

    [1;2;3] |> should contain 2

    "ships" |> should startWith "sh"

    11 |> should be (greaterThan 10)

    "" |> should be NullOrEmptyString

    ED209() |> should not' (be Null)











[<Fact>] 
let ``Mocking with Foq pretty similar to Moq`` () =

     // arrange
    let fakeWeaponStore = 
        Mock<IWeaponStore>()
            .Setup(fun x -> <@ x.GetIfAvailable(any()) @>).Returns(Weapon.Chainsaw)
            .Create()

    let robot = ED209(fakeWeaponStore)

    // act
    robot.Fire() |> ignore

    // assert
    Mock.Verify(<@ fakeWeaponStore.GetIfAvailable(any()) @>)











[<Fact>] 
let ``Object expressions can make framework-less moking easier`` () =

    // arrange
    let fakeWeaponStore = { new IWeaponStore with member ws.GetIfAvailable(_) = Weapon.Lazer }
    let robot = ED209(fakeWeaponStore)

    // act
    let result = robot.Fire()

    // assert
    result |> should equal Weapon.Lazer






// problems

// - no collection initialisers
// - no automatic type conversions
// - tools (e.g. fsUnit) not as mature as NUnit etc - less functionality


// Summary

// - Flexible test names
// - Less syntactical overhead
// - Nice fluent assertions
// - Give it a try!