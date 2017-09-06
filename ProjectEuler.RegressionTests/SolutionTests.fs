namespace ProjectEuler.RegressionTests

open FsUnit
open NUnit.Framework

module FSharpSolutions =

    open ProjectEuler.EulerFSharp

    [<Test>]
    let problem1 () = Problem1.solution |> should equal 233168

    [<Test>]
    let problem2 () = Problem2.solution |> should equal 4613732

    [<Test>]
    let problem3 () = Problem3.solution |> should equal 6857

    [<Test>]
    let problem21 () = Problem21.solution |> should equal 31626

    [<Test>]
    let problem31 () = Problem31.solution |> should equal 73682

    [<Test>]
    let problem76 () = Problem76.solution |> should equal 190569291

    [<Test>]
    let problem81 () = Problem81.solution |> should equal 427337

    [<Test>]
    let problem85 () = Problem85.solution |> should equal 2772

    [<Test>]
    let problem99 () = Problem99.solution |> should equal 709


//        [TestMethod]
//        public void Problem2()
//        {
//            Assert.AreEqual(4613732, problems.Problem2());
//        }
//
//        [TestMethod]
//        public void Problem3()
//        {
//            Assert.AreEqual(6857, problems.Problem3());
//        }
//
//        [TestMethod]
//        public void Problem4()
//        {
//            Assert.AreEqual(906609, problems.Problem4());
//        }
//
//        [TestMethod]
//        public void Problem5()
//        {
//            Assert.AreEqual(232792560, problems.Problem5());
//        }
//
//        [TestMethod]
//        public void Problem6()
//        {
//            Assert.AreEqual(25164150, problems.Problem6());
//        }
//
//        [TestMethod]
//        public void Problem7()
//        {
//            Assert.AreEqual(104743, problems.Problem7());
//        }
//
//        [TestMethod]
//        public void Problem8()
//        {
//            Assert.AreEqual(40824, problems.Problem8());
//        }
//
//        [TestMethod]
//        public void Problem9()
//        {
//            Assert.AreEqual(31875000, problems.Problem9());
//        }
//
//        [TestMethod]
//        public void Problem10()
//        {
//            Assert.AreEqual(142913828922, problems.Problem10());
//        }
//
//        [TestMethod]
//        public void Problem11()
//        {
//            Assert.AreEqual(70600674, problems.Problem11());
//        }
//
//        [TestMethod]
//        public void Problem12()
//        {
//            Assert.AreEqual(76576500, problems.Problem12());
//        }
//
//        [TestMethod]
//        public void Problem13()
//        {
//            Assert.AreEqual(5537376230, problems.Problem13());
//        }
//
//        [TestMethod]
//        public void Problem14()
//        {
//            Assert.AreEqual(837799, problems.Problem14());
//        }
//
//        [TestMethod]
//        public void Problem15()
//        {
//            Assert.AreEqual(137846528820, problems.Problem15());
//        }
//
//        [TestMethod]
//        public void Problem16()
//        {
//            Assert.AreEqual(1366, problems.Problem16());
//        }
//
//        [TestMethod]
//        public void Problem17()
//        {
//            Assert.AreEqual(21124, problems.Problem17());
//        }
//
//        [TestMethod]
//        public void Problem18()
//        {
//            Assert.AreEqual(1074, problems.Problem18());
//        }
//
//        [TestMethod]
//        public void Problem19()
//        {
//            Assert.AreEqual(171, problems.Problem19());
//        }
//
//        [TestMethod]
//        public void Problem20()
//        {
//            Assert.AreEqual(648, problems.Problem20());
//        }
//
//        [TestMethod]
//        public void Problem21()
//        {
//            Assert.AreEqual(31626, problems.Problem21());
//        }
//
//        [TestMethod]
//        public void Problem22()
//        {
//            Assert.AreEqual(871198282, problems.Problem22());
//        }
//
//        [TestMethod]
//        public void Problem23()
//        {
//            Assert.AreEqual(4179871, problems.Problem23());
//        }
//
//        [TestMethod]
//        public void Problem24()
//        {
//            Assert.AreEqual(2783915460, problems.Problem24());
//        }
//
//        [TestMethod]
//        public void Problem25()
//        {
//            Assert.AreEqual(4782, problems.Problem25());
//        }
//
//        [TestMethod]
//        public void Problem26()
//        {
//            Assert.AreEqual(983, problems.Problem26());
//        }
//
//        [TestMethod]
//        public void Problem27()
//        {
//            Assert.AreEqual(-59231, problems.Problem27());
//        }
//
//        [TestMethod]
//        public void Problem28()
//        {
//            Assert.AreEqual(669171001, problems.Problem28());
//        }
//
//        [TestMethod]
//        public void Problem29()
//        {
//            Assert.AreEqual(9183, problems.Problem29());
//        }
//
//        [TestMethod]
//        public void Problem30()
//        {
//            Assert.AreEqual(443839, problems.Problem30());
//        }
//
//        [TestMethod]
//        public void Problem31()
//        {
//            Assert.AreEqual(73682, problems.Problem31());
//        }
//
//        [TestMethod]
//        public void Problem32()
//        {
//            Assert.AreEqual(45228, problems.Problem32());
//        }
//
//        [TestMethod]
//        public void Problem33()
//        {
//            Assert.AreEqual(100, problems.Problem33());
//        }
//
//        [TestMethod]
//        public void Problem34()
//        {
//            Assert.AreEqual(40730, problems.Problem34());
//        }
//
//        [TestMethod]
//        public void Problem35()
//        {
//            Assert.AreEqual(55, problems.Problem35());
//        }
//
//        [TestMethod]
//        public void Problem36()
//        {
//            Assert.AreEqual(872187, problems.Problem36());
//        }
//
//        [TestMethod]
//        public void Problem37()
//        {
//            Assert.AreEqual(748317, problems.Problem37());
//        }
//
//        [TestMethod]
//        public void Problem38()
//        {
//            Assert.AreEqual(932718654, problems.Problem38());
//        }
//
//        [TestMethod]
//        public void Problem39()
//        {
//            Assert.AreEqual(840, problems.Problem39());
//        }
//
//        [TestMethod]
//        public void Problem40()
//        {
//            Assert.AreEqual(210, problems.Problem40());
//        }
//
//        [TestMethod]
//        public void Problem41()
//        {
//            Assert.AreEqual(7652413, problems.Problem41());
//        }
//
//        [TestMethod]
//        public void Problem42()
//        {
//            Assert.AreEqual(162, problems.Problem42());
//        }
//
//        [TestMethod]
//        public void Problem43()
//        {
//            Assert.AreEqual(16695334890, problems.Problem43());
//        }
//
//        [TestMethod]
//        public void Problem44()
//        {
//            Assert.AreEqual(5482660, problems.Problem44());
//        }
//
//        [TestMethod]
//        public void Problem45()
//        {
//            Assert.AreEqual(1533776805, problems.Problem45());
//        }
//
//        [TestMethod]
//        public void Problem46()
//        {
//            Assert.AreEqual(5777, problems.Problem46());
//        }
//
//        [TestMethod]
//        public void Problem47()
//        {
//            Assert.AreEqual(134043, problems.Problem47());
//        }
//
//        [TestMethod]
//        public void Problem48()
//        {
//            Assert.AreEqual(9110846700, problems.Problem48());
//        }
//
//        [TestMethod]
//        public void Problem49()
//        {
//            Assert.AreEqual(296962999629, problems.Problem49());
//        }
//
//        [TestMethod]
//        public void Problem50()
//        {
//            Assert.AreEqual(997651, problems.Problem50());
//        }
//
//        [TestMethod]
//        public void Problem51()
//        {
//            Assert.AreEqual(121313, problems.Problem51());
//        }
//
//        [TestMethod]
//        public void Problem52()
//        {
//            Assert.AreEqual(142857, problems.Problem52());
//        }
//
//        [TestMethod]
//        public void Problem53()
//        {
//            Assert.AreEqual(4075, problems.Problem53());
//        }
//
//        [TestMethod]
//        public void Problem54()
//        {
//            Assert.AreEqual(376, problems.Problem54());
//        }
//
//        [TestMethod]
//        public void Problem55()
//        {
//            Assert.AreEqual(249, problems.Problem55());
//        }
//
//        [TestMethod]
//        public void Problem56()
//        {
//            Assert.AreEqual(972, problems.Problem56());
//        }
//
//        [TestMethod]
//        public void Problem57()
//        {
//            Assert.AreEqual(153, problems.Problem57());
//        }
//
//        [TestMethod]
//        public void Problem59()
//        {
//            Assert.AreEqual(107359, problems.Problem59());
//        }
//
//        [TestMethod]
//        public void Problem63()
//        {
//            Assert.AreEqual(49, problems.Problem63());
//        }
//
//        [TestMethod]
//        public void Problem65()
//        {
//            Assert.AreEqual(272, problems.Problem65());
//        }
//
//        [TestMethod]
//        public void Problem67()
//        {
//            Assert.AreEqual(7273, problems.Problem67());
//        }
//
//        [TestMethod]
//        public void Problem69()
//        {
//            Assert.AreEqual(510510, problems.Problem69());
//        }
//
//        [TestMethod]
//        public void Problem70()
//        {
//            Assert.AreEqual(8319823, problems.Problem70());
//        }
//
//        [TestMethod]
//        public void Problem72()
//        {
//            Assert.AreEqual(303963552391, problems.Problem72());
//        }
//
//        [TestMethod]
//        public void Problem74()
//        {
//            Assert.AreEqual(402, problems.Problem74());
//        }
//
//        [TestMethod]
//        public void Problem76()
//        {
//            Assert.AreEqual(190569291, problems.Problem76());
//        }
//
//        [TestMethod]
//        public void Problem79()
//        {
//            Assert.AreEqual(73162890, problems.Problem79());
//        }
//
//        [TestMethod]
//        public void Problem81()
//        {
//            Assert.AreEqual(427337, problems.Problem81());
//        }
//
//        [TestMethod]
//        public void Problem85()
//        {
//            Assert.AreEqual(2772, problems.Problem85());
//        }
//
//        [TestMethod]
//        public void Problem89()
//        {
//            Assert.AreEqual(743, problems.Problem89());
//        }
//
//        [TestMethod]
//        public void Problem92()
//        {
//            Assert.AreEqual(8581146, problems.Problem92());
//        }
//
//        [TestMethod]
//        public void Problem97()
//        {
//            Assert.AreEqual(8739992577, problems.Problem97());
//        }
//
//        [TestMethod]
//        public void Problem99()
//        {
//            Assert.AreEqual(709, problems.Problem99());
//        }
//
//        [TestMethod]
//        public void Problem112()
//        {
//            Assert.AreEqual(1587000, problems.Problem112());
//        }
//
//        [TestMethod]
//        public void Problem144()
//        {
//            Assert.AreEqual(354, problems.Problem144());
//        }
//
//        [TestMethod]
//        public void Problem202()
//        {
//            Assert.AreEqual(1209002624, problems.Problem202());
//        }
//
//        [TestMethod]
//        public void Problem206()
//        {
//            Assert.AreEqual(1389019170, problems.Problem206());
//        }
//
//        [TestMethod]
//        public void Problem235()
//        {
//            Assert.AreEqual(1.002322108633, problems.Problem235(), 0.0000000000005);
//        }
//
//        [TestMethod]
//        public void Problem243()
//        {
//            Assert.AreEqual(892371480, problems.Problem243(), 0.0000000000005);
//        }
//    }
//}
//
//
