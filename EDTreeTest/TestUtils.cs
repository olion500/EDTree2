using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EDTree2;
using NUnit.Framework;

namespace EDTreeTest
{
    public class TestUtils
    {
        [Test]
        public void TestLinearFunction()
        {
            Assert.AreEqual(1, Math.Pow(2, 0));
            
            Assert.AreEqual(4, Utils.LinearF(new[] {4.0}, 20), "0 dim polynomial equation won't work with value x");
            
            Assert.AreEqual(164, Utils.LinearF(new[] {4.0, 8.0}, 20), "1 dim polynomial equation.");
            
            Assert.AreEqual(60, Utils.LinearF(new[] {4.0, 8.0, 10.0}, 2), "2 dim polynomial equation.");
            
            Assert.AreEqual(122.05, Utils.LinearF(new[] {4.0, 8.0, 10.0, 0.15}, 3), "3 dim polynomial equation.");
            
            Assert.AreEqual(4.425, Utils.LinearF(new[] {4.0, 8.0, 10.0, 0.15}, 0.05), "3 dim polynomial equation with small values.");
            
            Assert.AreEqual(4, Utils.LinearF(new[] {4.0, 8.0, 10.0, 0.15}, 0), "Polynomial equation when x = 0");
            
            Assert.AreEqual(3.625, Utils.LinearF(new[] {4.0, 8.0, 10.0, 0.15}, -0.05), "Polynomial equation when x < 0");
        }

        [Test]
        public void TestMultiplyArray()
        {
            CollectionAssert.AreEqual(new[] {2,4,6}, Utils.MultiplyArray(new double[] {1,2,3}, 2));
            
            CollectionAssert.AreEqual(new[] {0.5, 1, 1.5}, Utils.MultiplyArray(new double[] {1,2,3}, 0.5));
            
            CollectionAssert.AreEqual(new[] {0, 0, 0}, Utils.MultiplyArray(new double[] {1,2,3}, 0));
        }

        [Test]
        public void TestFindX()
        {
            List<double> x = new List<double>() {1.0, 2, 3, 4};
            List<double> y = x.Select(t => t * t).ToList();

            CollectionAssert.AreEqual(new List<double>() {1},Utils.FindXIndex(y, 4));

            x = new List<double>() {-4.0, -3, -2, -1, 0, 1, 2, 3, 4};
            y = x.Select(t => t * t).ToList();
            CollectionAssert.AreEqual(new List<double>() {2, 6}, Utils.FindXIndex(y, 4));
        }

        [Test]
        public void TestFindCircumcenter()
        {
            var cc = Utils.FindCircumcenter(new PointF(6f, 0f), new PointF(0f, 0f), new PointF(0f, 8f));
            Assert.AreEqual(new PointF(3f, 4f), cc);

            cc = Utils.FindCircumcenter(new PointF(1, 1), new PointF(0, 0), new PointF(2, 2));
            // cannot be calculated.
        }
        
        [Test]
        public void TestPointDistance()
        {
            var dist = Utils.PointDistance(new PointF(12f, 11f), new PointF(13f, 10f));
            Assert.AreEqual(1.414, dist, 0.001);
            
            dist = Utils.PointDistance(new PointF(0f, 1f), new PointF(0f, 0f));
            Assert.AreEqual(1, dist);
            
            dist = Utils.PointDistance(new PointF(0f, 0f), new PointF(0f, 0f));
            Assert.AreEqual(0, dist);
        }
    }
}