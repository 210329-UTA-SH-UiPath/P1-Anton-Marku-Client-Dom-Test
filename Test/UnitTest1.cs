using PizzaBoxApi.Models;
using System;
using Xunit;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var sut = new Size();
            sut.Type = "big";
            var actual = sut.Type;
            Assert.True(actual == "big");
        }

        [Fact]
        public void Test2()
        {
            var sut = new Size();
            sut.Type = "small";
            var actual = sut.Type;
            Assert.True(actual == "small");
        }

        [Fact]
        public void Test3()
        {
            var sut = new Size();
            sut.Type = "largew";
            var actual = sut.Type;
            Assert.True(actual == "largew");
        }

        [Fact]
        public void Test4()
        {
            var sut = new Size();
            sut.Type = "sdfgsd";
            var actual = sut.Type;
            Assert.True(actual == "sdfgsd");
        }

        [Fact]
        public void Test5()
        {
            var sut = new Size();
            sut.Type = "kghjkm";
            var actual = sut.Type;
            Assert.True(actual == "kghjkm");
        }

        [Fact]
        public void Test6()
        {
            var sut = new Size();
            sut.Type = "1234";
            var actual = sut.Type;
            Assert.True(actual == "1234");
        }

        [Fact]
        public void Test7()
        {
            var sut = new Size();
            sut.Type = "tyuik768";
            var actual = sut.Type;
            Assert.True(actual == "tyuik768");
        }

        [Fact]
        public void Test8()
        {
            var sut = new Size();
            sut.Type = "iop][iop";
            var actual = sut.Type;
            Assert.True(actual == "iop][iop");
        }

        [Fact]
        public void Test9()
        {
            var sut = new Size();
            sut.Type = "bxdfgsbv";
            var actual = sut.Type;
            Assert.True(actual == "bxdfgsbv");
        }

        [Fact]
        public void Test10()
        {
            var sut = new Size();
            sut.Type = "xfgnbxc";
            var actual = sut.Type;
            Assert.True(actual == "xfgnbxc");
        }

        [Fact]
        public void Test11()
        {
            var sut = new Size();
            sut.Type = "vsxzdfsh";
            var actual = sut.Type;
            Assert.True(actual == "vsxzdfsh");
        }

        [Fact]
        public void Test12()
        {
            var sut = new Size();
            sut.Type = "cvbnjmfghkj";
            var actual = sut.Type;
            Assert.True(actual == "cvbnjmfghkj");
        }

        [Fact]
        public void Test13()
        {
            var sut = new Size();
            sut.Type = "43tqerdfvgzdfs";
            var actual = sut.Type;
            Assert.True(actual == "43tqerdfvgzdfs");
        }

        [Fact]
        public void Test14()
        {
            var sut = new Size();
            sut.Type = "1q324wagtedrf";
            var actual = sut.Type;
            Assert.True(actual == "1q324wagtedrf");
        }

        [Fact]
        public void Test15()
        {
            var sut = new Size();
            sut.Type = "fngsdrt5y";
            var actual = sut.Type;
            Assert.True(actual == "fngsdrt5y");
        }
    }
}
