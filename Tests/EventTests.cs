using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Tests
{
    class EventTests
    {
        [Test]
        public void Event_checkIfParseDateIsCorrect_Parsed() { 
            Assert.IsTrue(DateTime.TryParse("10/12/2020", out DateTime date));
        }
    }
}
