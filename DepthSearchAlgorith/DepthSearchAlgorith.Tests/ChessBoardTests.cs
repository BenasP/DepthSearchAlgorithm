using System.Collections.Generic;
using NUnit.Framework;

namespace DepthSearchAlgorith.Tests
{
    [TestFixture]
    public class ChessBoardTests
    {
        public class CorrectFormat : ChessBoardTests
        {
            private int[,] response;

            [SetUp]
            public void InitTest()
            {
                var operation = new ChessBoard(new int[15, 15], new List<string>(), 5);
                response = operation.Run();
            }

            [Test]
            public void ShouldReturnSameSizeMatrix()
            {
                Assert.AreEqual(response.GetLength(0), 15);
                Assert.AreEqual(response.GetLength(1), 15);
            }

            [Test]
            public void ShouldMatrixContainCorrectAmountOfObjects()
            {
                var count = 0;
                for (int i = 0; i < 15; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        if (response[i, j] == 1)
                        {
                            count++;
                        }
                    }
                }

                Assert.AreEqual(count, 225);
            }

        }

        public class HorizontalFigureCrossingOut : ChessBoardTests
        {
            private int[,] response;

            [SetUp]
            public void InitTest()
            {
                var operation = new ChessBoard(new int[3, 3], new List<string> { "H" }, 3);
                response = operation.Run();
            }

            [Test]
            public void ShouldNotBeAnyObjectInTheSameLine()
            {
                var isInTheSameLine = false;

                for (int i = 0; i < 3; i++)
                {
                    var count = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        if (response[i, j] == 1)
                        {
                            count++;
                        }
                    }
                    if (count > 1)
                    {
                        isInTheSameLine = true;
                    }
                }

                Assert.IsFalse(isInTheSameLine);
            }
        }

        public class VerticalFigureCrossingOut : ChessBoardTests
        {
            private int[,] response;

            [SetUp]
            public void InitTest()
            {
                var operation = new ChessBoard(new int[3, 3], new List<string> { "V" }, 3);
                response = operation.Run();
            }

            [Test]
            public void ShouldNotBeAnyObjectInTheSameColumn()
            {
                var inTheSameColumn = false;

                for (int j = 0; j < 3; j++)
                {
                    var count = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        if (response[i, j] == 1)
                        {
                            count++;
                        }
                    }
                    if (count > 1)
                    {
                        inTheSameColumn = true;
                    }
                }

                Assert.IsFalse(inTheSameColumn);
            }
        }

        public class ObliquelyFigureCrossingOut : ChessBoardTests
        {
            private int[,] response;

            [SetUp]
            public void InitTest()
            {
                var operation = new ChessBoard(new int[3, 3], new List<string> { "O" }, 1);
                response = operation.Run();
            }

            [Test]
            public void ShouldNotBeAnyObjectInTheSameColumn()
            {
                var inTheSameDiagonal = false;

                for (int j = 0; j < 3; j++)
                {
                    var count = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        if (response[j, i] == 1)
                        {
                            
                        }
                    }
                    if (count > 1)
                    {
                        inTheSameDiagonal = true;
                    }
                }

                Assert.IsFalse(inTheSameDiagonal);
            }
        }
    }
}
