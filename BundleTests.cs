using NUnit.Framework;

namespace Task1.UnitTests
{
    [TestFixture]
    public class AngleTests
    {
        [Test]
        public void ConstructorTest()
        {
            var bundle = new Bundle(5, 10);
            Assert.That(bundle.BanknoteType, Is.EqualTo(5));
            Assert.That(bundle.Count, Is.EqualTo(10));
            
        }

        [TestCase(-1)]
        public void NegativeCountTest_ArgumentException(int val)
        {
            var bundle = new Bundle();
            Assert.That(() => bundle.Count = val, Throws.ArgumentException);
        }
        
        [TestCase(18)]
        public void BanknoteTest_ArgumentException(int val)
        {
            var bundle = new Bundle();
            Assert.That(() => bundle.BanknoteType = val, Throws.ArgumentException);
        }

        [TestCase(50, 6)]
        public void BundleSumTest(int banknote, int count)
        {
            var bundle = new Bundle(banknote, count);
            Assert.That(bundle.Sum, Is.EqualTo(300));
        }
        
        [TestCase(100, 16, "16 x 100 р.")]
        [TestCase(5000, 2, "2 x 5000 р.")]
        public void ToStringTest(int banknote, int count, string result)
        {
            var bundle = new Bundle(banknote, count);
            Assert.That(bundle.ToString(), Is.EqualTo(result));
        }
        
        [TestCase(100, 16, 100, 16, true)]
        [TestCase(5000, 2, 500, 2, false)]
        public void EqualityTest(int banknote1, int count1, int banknote2, int count2, bool result)
        {
            var bundle1 = new Bundle(banknote1, count1);
            var bundle2 = new Bundle(banknote2, count2);
            Assert.That(bundle1.Equals(bundle2), Is.EqualTo(result));
        }
        
        [TestCase(5000, 2)]
        public void EqualityTest_ArgumentException(int banknote1, int count1)
        {
            var bundle1 = new Bundle(banknote1, count1);
            var bundle2 = new object();
            Assert.That(() => bundle1.Equals(bundle2), Throws.ArgumentException);
        }
        
        [Test]
        public static void ComparisonTest()
        {
            var x = new Bundle(1, 2);
            var y = new Bundle(1, 2);
            var z = new Bundle(2, 23);
            Assert.That(x == y, Is.True);
            Assert.That(x != y, Is.False);
            Assert.That(x == z, Is.False);
            Assert.That(x != z, Is.True);
        }
        
        [TestCase(100, 1, 100, 2, 100, 3)]
        [TestCase(5000, 20, 5000, 2, 5000, 22)]
        public void AdditionTest(int banknote1, int count1, int banknote2, int count2, int resBanknote, int resCount)
        {
            var bundle1 = new Bundle(banknote1, count1);
            var bundle2 = new Bundle(banknote2, count2);
            var expected = new Bundle(resBanknote, resCount);
            Assert.That(bundle1 + bundle2, Is.EqualTo(expected));
        }
        
        [TestCase(100, 1, 1000, 1)]
        public void AdditionTest_ArgumentException(int banknote1, int count1, int banknote2, int count2)
        {
            var bundle1 = new Bundle(banknote1, count1);
            var bundle2 = new Bundle(banknote2, count2);
            Assert.That(() => bundle1 + bundle2, Throws.ArgumentException);
        }
        
        [TestCase(100, 2, 100, 1, 100, 1)]
        [TestCase(5000, 20, 5000, 20, 5000, 0)]
        public void SubtractionTest(int banknote1, int count1, int banknote2, int count2, int resBanknote, int resCount)
        {
            var bundle1 = new Bundle(banknote1, count1);
            var bundle2 = new Bundle(banknote2, count2);
            var expected = new Bundle(resBanknote, resCount);
            Assert.That(bundle1 - bundle2, Is.EqualTo(expected));
        }
        
        [TestCase(100, 1, 1000, 1)]
        [TestCase(1000, 1, 1000, 3)]
        public void SubtractionTest_ArgumentException(int banknote1, int count1, int banknote2, int count2)
        {
            var bundle1 = new Bundle(banknote1, count1);
            var bundle2 = new Bundle(banknote2, count2);
            Assert.That(() => bundle1 - bundle2, Throws.ArgumentException);
        }
    }
}