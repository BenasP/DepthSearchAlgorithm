using NUnit.Framework;

namespace DepthSearchAlgorith.Tests
{
    [TestFixture]
    public class ChessBoardTests
    {
        public class KnightStyleCheckWithArray : ChessBoardTests
        {
            [Test]
            public void ShouldCheckUpByOneLeftByTwo()
            {
                var request = new int[] { 1, 0, 2 };

                var response = new ChessBoard(request).IsKnightStyleCrossingOutClearInArray(2, 1);

                Assert.IsFalse(response);
            }

            [Test]
            public void ShouldCheckUpByTwoLeftByOne()
            {
                var request = new int[,]
                              {
                                  { 1, 0, 0},
                                  { 0, 0, 0},
                                  { 0, 1, 0}
                              };

                var response = new ChessBoard(request).IsKnightStyleCrossingOutClear(1, 2);

                Assert.IsFalse(response);
            }

            [Test]
            public void ShouldCheckDownByOneLeftByTwo()
            {
                var request = new int[,]
                              {
                                  { 0, 0, 0},
                                  { 0, 0, 1},
                                  { 1, 0, 0}
                              };

                var response = new ChessBoard(request).IsKnightStyleCrossingOutClear(2, 1);

                Assert.IsFalse(response);
            }

            [Test]
            public void ShouldCheckDownByTwoLeftByOne()
            {
                var request = new int[,]
                              {
                                  { 0, 1, 0},
                                  { 0, 0, 0},
                                  { 1, 0, 0}
                              };

                var response = new ChessBoard(request).IsKnightStyleCrossingOutClear(1, 0);

                Assert.IsFalse(response);
            }

            [Test]
            public void ShouldFindAnyElement()
            {
                var request = new int[,]
                              {
                                  { 1, 1, 0, 1, 1},
                                  { 1, 0, 1, 1, 1},
                                  { 1, 1, 1, 1, 1},
                                  { 1, 0, 1, 1, 1},
                                  { 1, 1, 0, 1, 1}
                              };

                var response = new ChessBoard(request).IsKnightStyleCrossingOutClear(3, 2);

                Assert.IsTrue(response);
            }
        }

        public class RowCheckWithArray : ChessBoardTests
        {
            [Test]
            public void ShouldNotFindAnyElementInRow()
            {
                var request = new int[] { 1, 3, 8 };
                var response = new ChessBoard(request).IsRowClearInArray(9);

                Assert.IsTrue(response);
            }

            [Test]
            public void ShouldFindAnyElementInRow()
            {
                var request = new int[] { 1, 3, 9 };
                var response = new ChessBoard(request).IsRowClearInArray(9);

                Assert.IsFalse(response);
            }
        }

        public class ObliquelyChechWithArray : ChessBoardTests
        {
            [Test]
            public void ShouldNotFindElementAnyInDescObliquely()
            {
                var request = new int[] { 1, 7, 0 };
                var response = new ChessBoard(request).IsObliqueliesClearInArray(2, 5);

                Assert.IsTrue(response);
            }

            [Test]
            public void ShouldFindElementInDescObliquely()
            {
                var request = new int[] { 1, 7, 0 };
                var response = new ChessBoard(request).IsObliqueliesClearInArray(2, 8);

                Assert.IsFalse(response);
            }

            [Test]
            public void ShouldNotFindElementAnyInAscObliquely()
            {
                var request = new int[] { 1, 7, 0};
                var response = new ChessBoard(request).IsObliqueliesClearInArray(2, 5);

                Assert.IsTrue(response);
            }

            [Test]
            public void ShouldFindElementInAscObliquely()
            {
                var request = new int[] { 1, 7, 0 };
                var response = new ChessBoard(request).IsObliqueliesClearInArray(2, 6);

                Assert.IsFalse(response);
            }
        }

        public class RowCheck : ChessBoardTests
        {
            [Test]
            public void ShouldNotFindAnyElementInRow()
            {
                var request = new int[,]
                              {
                                  { 0, 1, 0},
                                  { 0, 0, 0},
                                  { 0, 1, 0}
                              };
                var response = new ChessBoard(request).IsRowClear(2, 1);

                Assert.IsTrue(response);
            }

            [Test]
            public void ShouldNotCheckIfItsTheFirstCol()
            {
                var request = new int[,]
                              {
                                  { 0, 1, 0},
                                  { 1, 0, 0},
                                  { 0, 1, 0}
                              };
                var response = new ChessBoard(request).IsRowClear(0, 1);

                Assert.IsTrue(response);
            }

            [Test]
            public void ShouldFindElementInRow()
            {
                var request = new int[,]
                             {
                                  { 0, 1, 0},
                                  { 1, 0, 0},
                                  { 0, 1, 0}
                             };
                var response = new ChessBoard(request).IsRowClear(2, 1);

                Assert.IsFalse(response);
            }

            [Test]
            public void ShouldNotCheckPositionThatIsPassed()
            {
                var request = new int[,]
                             {
                                  { 0, 1, 0},
                                  { 0, 1, 0},
                                  { 0, 1, 0}
                             };
                var response = new ChessBoard(request).IsRowClear(1, 1);

                Assert.IsTrue(response);
            }
        }

        public class ColumnCheck : ChessBoardTests
        {
            [Test]
            public void ShouldNotFindAnyElementInCol()
            {
                var request = new int[,]
                              {
                                  { 0, 0, 0},
                                  { 0, 1, 1},
                                  { 0, 0, 0}
                              };
                var response = new ChessBoard(request).IsColumnClear(0, 2);

                Assert.IsTrue(response);
            }

            [Test]
            public void ShouldNotCheckIfItsTheFirstCol()
            {
                var request = new int[,]
                              {
                                  { 0, 1, 0},
                                  { 1, 0, 1},
                                  { 0, 0, 0}
                              };
                var response = new ChessBoard(request).IsColumnClear(1, 0);

                Assert.IsTrue(response);
            }

            [Test]
            public void ShouldFindElementInCol()
            {
                var request = new int[,]
                             {
                                  { 0, 1, 0},
                                  { 1, 0, 1},
                                  { 0, 0, 0}
                             };
                var response = new ChessBoard(request).IsColumnClear(2, 2);

                Assert.IsFalse(response);
            }

            [Test]
            public void ShouldNotCheckPositionThatIsPassed()
            {
                var request = new int[,]
                             {
                                  { 0, 0, 0},
                                  { 1, 1, 1},
                                  { 0, 0, 0}
                             };
                var response = new ChessBoard(request).IsColumnClear(1, 1);

                Assert.IsTrue(response);
            }
        }

        public class ObliquelyCheck : ChessBoardTests
        {
            [Test]
            public void ShouldNotFindElementAnyInDescObliquely()
            {
                var request = new int[,]
                              {
                                  { 0, 0, 0},
                                  { 0, 0, 0},
                                  { 0, 1, 0}
                              };
                var response = new ChessBoard(request).IsObliqueliesClear(1, 2);

                Assert.IsTrue(response);
            }

            [Test]
            public void ShouldFindElementInDescObliquely()
            {
                var request = new int[,]
                              {
                                  { 0, 0, 0},
                                  { 1, 0, 0},
                                  { 0, 1, 0}
                              };
                var response = new ChessBoard(request).IsObliqueliesClear(1, 2);

                Assert.IsFalse(response);
            }

            [Test]
            public void ShouldNotFindElementAnyInAscObliquely()
            {
                var request = new int[,]
                              {
                                  { 0, 1, 0},
                                  { 0, 0, 0},
                                  { 0, 0, 0}
                              };
                var response = new ChessBoard(request).IsObliqueliesClear(1, 0);

                Assert.IsTrue(response);
            }

            [Test]
            public void ShouldFindElementInAscObliquely()
            {
                var request = new int[,]
                              {
                                  { 0, 1, 0},
                                  { 1, 0, 0},
                                  { 0, 0, 0}
                              };
                var response = new ChessBoard(request).IsObliqueliesClear(1, 0);

                Assert.IsFalse(response);
            }

        }

        public class KnightSylecheck : ChessBoardTests
        {
            [Test]
            public void ShouldCheckUpByOneLeftByTwo()
            {
                var request = new int[,]
                              {
                                  { 1, 0, 0},
                                  { 0, 0, 1},
                                  { 0, 0, 0}
                              };

                var response = new ChessBoard(request).IsKnightStyleCrossingOutClear(2, 1);

                Assert.IsFalse(response);
            }

            [Test]
            public void ShouldCheckUpByTwoLeftByOne()
            {
                var request = new int[,]
                              {
                                  { 1, 0, 0},
                                  { 0, 0, 0},
                                  { 0, 1, 0}
                              };

                var response = new ChessBoard(request).IsKnightStyleCrossingOutClear(1, 2);

                Assert.IsFalse(response);
            }

            [Test]
            public void ShouldCheckDownByOneLeftByTwo()
            {
                var request = new int[,]
                              {
                                  { 0, 0, 0},
                                  { 0, 0, 1},
                                  { 1, 0, 0}
                              };

                var response = new ChessBoard(request).IsKnightStyleCrossingOutClear(2, 1);

                Assert.IsFalse(response);
            }

            [Test]
            public void ShouldCheckDownByTwoLeftByOne()
            {
                var request = new int[,]
                              {
                                  { 0, 1, 0},
                                  { 0, 0, 0},
                                  { 1, 0, 0}
                              };

                var response = new ChessBoard(request).IsKnightStyleCrossingOutClear(1, 0);

                Assert.IsFalse(response);
            }

            [Test]
            public void ShouldNotFindAnyElement()
            {
                var request = new int[,]
                              {
                                  { 1, 1, 0, 1, 1},
                                  { 1, 0, 1, 1, 1},
                                  { 1, 1, 1, 1, 1},
                                  { 1, 0, 1, 1, 1},
                                  { 1, 1, 0, 1, 1}
                              };

                var response = new ChessBoard(request).IsKnightStyleCrossingOutClear(3, 2);

                Assert.IsTrue(response);
            }
        }
    }
}
