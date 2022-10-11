﻿using Model.Business.Entries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Model_Tests.Business.Entries
{
    public class Entry_Tests
    {
        /// <summary>
        /// Test the equality protocol
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [Theory]
        [MemberData(nameof(EntryComparer_Tests.Equals_TestData), MemberType = typeof(EntryComparer_Tests))]
        public void Equals_Tests(bool expected, Entry x, Entry? y)
        {
            Assert.Equal(expected, x.Equals(y));
        }

        public static readonly object?[] Equals_TestData_Nullable
            = new object?[] { false, new SharedEntry("Login", "1234", "Discord"), null };

        /// <summary>
        /// Test the GetHashCode method.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        [Theory]
        [MemberData(nameof(EntryComparer_Tests.GetHashCode_TestData), MemberType = typeof(EntryComparer_Tests))]
        public void GetHashCode_Tests(Entry x, Entry y)
        {
            bool equals = x.Equals(y);
            bool hashEquals = x.GetHashCode() == y.GetHashCode();
            Assert.Equal(equals, hashEquals);
        }
    }
}
