using NUnit.Framework;
using Rhino.Mocks;
using RockPaperScissors.Common.Interfaces;
using RockPaperScissors.Common.PlayersImplementation;
using RockPaperScissors.Common.Rules;
using System;

namespace UnitTests
{
    public class AdditionalTests
    {
        [Test]
        public void RockPaperScissorsRules_GetNextWinningMove_InvalidMoveThrows()
        {
            var rules = new RockPaperScissorsRules();
            Assert.Throws<Exception>(() => rules.GetNextWinningMove(0));
        }

        [Test]
        [Repeat(10)]
        public void RockPaperScissorsRules_GetRandomMove_ReturnsValidRange()
        {
            var rules = new RockPaperScissorsRules();
            int move = rules.GetRandomMove();
            Assert.That(move, Is.InRange(1, 3));
        }

        [Test]
        public void TacticalPlayer_FirstMoveRandomSecondMoveWinning()
        {
            var rules = MockRepository.GenerateMock<IRules>();
            rules.Expect(r => r.GetRandomMove()).Return(2).Repeat.Once();
            rules.Expect(r => r.GetNextWinningMove(2)).Return(3).Repeat.Once();

            var player = new TacticalPlayer();

            int first = player.GetNextMove(rules);
            int second = player.GetNextMove(rules);

            Assert.AreEqual(2, first);
            Assert.AreEqual(3, second);
            rules.VerifyAllExpectations();
        }
    }
}
