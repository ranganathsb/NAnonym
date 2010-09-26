﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Urasandesu.NAnonym;

namespace Test.Urasandesu.NAnonym
{
    [TestFixture]
    public class StringUtilityTest
    {
        [Test]
        public void CsvEncodeTest01()
        {
            Assert.AreEqual("a\"\"", "a\"".CsvEncode());
            Assert.AreEqual("a''", "a'".CsvEncode("'"));
            Assert.AreEqual("\"a\",\"b\",\"c\"", new string[] { "a", "b", "c" }.CsvEncode());
            Assert.AreEqual("'a','b','c'", new string[] { "a", "b", "c" }.CsvEncode("'"));
            Assert.AreEqual("'a';'b';'c'", new string[] { "a", "b", "c" }.CsvEncode("'", ";"));
        }



        [Test]
        public void CsvEncodeTest02()
        {
            Assert.AreEqual("a\"\"\"", "a\"".CommandPromptEncode());
            Assert.AreEqual("a'''", "a'".CommandPromptEncode("'"));
            Assert.AreEqual("\"a\" \"b\" \"c\"", new string[] { "a", "b", "c" }.CommandPromptEncode());
            Assert.AreEqual("'a' 'b' 'c'", new string[] { "a", "b", "c" }.CommandPromptEncode("'"));
            Assert.AreEqual("'a';'b';'c'", new string[] { "a", "b", "c" }.CommandPromptEncode("'", ";"));
        }



        [Test]
        public void ToDateTimeFuzzyTest01()
        {
            DateTime expected = new DateTime(2008, 4, 10);
            DateTime actual;
            Assert.AreEqual(expected, "04/10/2008".FuzzyConvertToDateTime());
            Assert.AreEqual(expected, "Thursday, 10 April 2008".FuzzyConvertToDateTime());
            Assert.AreEqual(expected, "Thursday, 10 April 2008 00:00".FuzzyConvertToDateTime());
            Assert.AreEqual(expected, "Thursday, 10 April 2008 00:00:00".FuzzyConvertToDateTime());
            Assert.AreEqual(expected, "04/10/2008 00:00".FuzzyConvertToDateTime());
            Assert.AreEqual(expected, "04/10/2008 00:00:00".FuzzyConvertToDateTime());
            actual = "April 10".FuzzyConvertToDateTime();
            Assert.AreEqual(expected.Month, actual.Month);
            Assert.AreEqual(expected.Day, actual.Day);
            Assert.AreEqual(expected, "Thu, 10 Apr 2008 00:00:00 GMT".FuzzyConvertToDateTime());
            Assert.AreEqual(expected, "2008-04-10T00:00:00".FuzzyConvertToDateTime());
            actual = "00:00".FuzzyConvertToDateTime();
            Assert.AreEqual(expected.Hour, actual.Hour);
            Assert.AreEqual(expected.Minute, actual.Minute);
            actual = "00:00:00".FuzzyConvertToDateTime();
            Assert.AreEqual(expected.Hour, actual.Hour);
            Assert.AreEqual(expected.Minute, actual.Minute);
            Assert.AreEqual(expected.Second, actual.Second);
            Assert.AreEqual(expected, "2008-04-10 00:00:00Z".FuzzyConvertToDateTime());
            Assert.AreEqual(expected.ToUniversalTime(), "Wednesday, 09 April 2008 15:00:00".FuzzyConvertToDateTime());
            actual = "2008 April".FuzzyConvertToDateTime();
            Assert.AreEqual(expected.Year, actual.Year);
            Assert.AreEqual(expected.Month, actual.Month);
            Assert.AreEqual(expected.ToUniversalTime(), "Thu Apr 10 00:00:00 +09:00 2008".FuzzyConvertToDateTime());
        }




        [Test]
        public void WithoutExtensionTest01()
        {
            string uri = "file:///C:/Documents and Settings/Administrator/NTroll/Test.Urasandesu.NTroll.GlobalClassTestSample/bin/Debug/Urasandesu.NTroll.GlobalClassTestSample.DLL";
            string path = "C:\\Documents and Settings\\Administrator\\Local Settings\\Application Data\\assembly\\dl3\\M7C3NZ7V.KL7\\826D3A82.LND\\4a4fb7a3\\3ef45ff7_505dcb01\\Urasandesu.NTroll.GlobalClassTestSample.DLL";

            Assert.AreEqual("file:///C:/Documents and Settings/Administrator/NTroll/Test.Urasandesu.NTroll.GlobalClassTestSample/bin/Debug/Urasandesu.NTroll.GlobalClassTestSample", uri.WithoutExtension());
            Assert.AreEqual("C:\\Documents and Settings\\Administrator\\Local Settings\\Application Data\\assembly\\dl3\\M7C3NZ7V.KL7\\826D3A82.LND\\4a4fb7a3\\3ef45ff7_505dcb01\\Urasandesu.NTroll.GlobalClassTestSample", path.WithoutExtension());
        }



        //[Test]
        //public void Hoge()
        //{
        //    var stopwatch = new System.Diagnostics.Stopwatch();
        //    string a = "a";
        //    string a10000 = new string('a', 10000);
        //    string ae = new string('\"', 1000);
        //    string result = null;

        //    stopwatch.Reset();
        //    stopwatch.Start();
        //    for (int i = 0; i < 100000; i++)
        //    {
        //        result = a.CsvEncode();
        //    }
        //    stopwatch.Stop();
        //    Console.WriteLine("Time: {0} ms", stopwatch.ElapsedMilliseconds);

        //    stopwatch.Reset();
        //    stopwatch.Start();
        //    for (int i = 0; i < 100000; i++)
        //    {
        //        result = a10000.CsvEncode();
        //    }
        //    stopwatch.Stop();
        //    Console.WriteLine("Time: {0} ms", stopwatch.ElapsedMilliseconds);

        //    stopwatch.Reset();
        //    stopwatch.Start();
        //    for (int i = 0; i < 100000; i++)
        //    {
        //        result = ae.CsvEncode();
        //    }
        //    stopwatch.Stop();
        //    Console.WriteLine("Time: {0} ms", stopwatch.ElapsedMilliseconds);
        //}
    }
}
