using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace GameFifteen
{
    [TestFixture]
    public class WalkInMatrixTests
    {
        [TestCase(2,2,1,1,3)]
        public void TestIsOutOfBoundaries_ShouldReturnTrue_WhenIsOutOfBounderies(int currentX, int currentY, int dx,
            int dy, int size)
        {
            var result = IsOutOfBoundaries(currentX, currentY, dx, dy, size);
        }
    }
}
