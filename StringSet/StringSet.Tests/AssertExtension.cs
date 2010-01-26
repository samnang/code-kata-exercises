using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace StringSet.Tests {
    public static class AssertExtension {
        public static void ShouldBeEqual<T>(this T actual, T expected) 
        {
            Assert.AreEqual(expected, actual);
        }
    }
}
