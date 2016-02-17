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
                var operation = new ChessBoard(new int[15,15]);
                response = operation.Run();
            }

            [Test]
            public void ShouldReturnSameSizeMatrix()
            {
                Assert.AreEqual(response.GetLength(0), 15);
                Assert.AreEqual(response.GetLength(1), 15);
            }

            [Test]
            public void ShouldMatrixContainTenObjects()
            {
                var count = 0;
                for (int i = 0; i < 15; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        if (response[i, j] != 0)
                        {
                            count++;
                        }
                    }
                }

                Assert.AreEqual(count, 10);
            }
        }

        public class HorizontalFigureCrossingOut : ChessBoardTests
        {
             
        }
    }
}
