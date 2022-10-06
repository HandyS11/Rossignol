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
        [Theory]
        [MemberData(nameof(EntryComparer_Tests.Equals_TestData), MemberType = typeof(EntryComparer_Tests))]
        public void Equals_Tests(bool expected, Entry x, Entry? y)
        {
            Assert.Equal(expected, x.Equals(y));
        }

        public static readonly object?[] Equals_TestData_Nullable
            = new object?[] { false, new SharedEntry("Login", "1234", "Discord"), null };

        [Theory]
        [MemberData(nameof(EntryComparer_Tests.GetHashCode_TestData), MemberType = typeof(EntryComparer_Tests))]
        public void GetHashCode_Tests(Entry x, Entry y)
        {
            bool equals = x.Equals(y);
            bool hashEquals = x.GetHashCode() == y.GetHashCode();
            Assert.Equal(equals, hashEquals);
        }

        private readonly Entry entry = new ProprietaryEntry("lorem", "ipsum", "dolore");

        [Theory]
        [MemberData(nameof(NonEntryEquals_TestData))]
        public void Equals_Tests_NonEntryObjects(object? o)
        {
            Assert.False(entry.Equals(o));
        }

        public static IEnumerable<object?[]> NonEntryEquals_TestData()
        {
            yield return new object?[] { null };
            yield return new object[] { 1 };
            yield return new object[] { 'a' };
            yield return new object[] { new Exception() };
            yield return new object[] { new List<float>() };
            yield return new object[] { DateTime.Now };
        }

        [Fact]
        public void Equals_ObjectCastedEntry_ShouldReturnTrue()
        {
            Entry a = new SharedEntry("lorem", "ipsum", "dolore");
            object b = new SharedEntry("lorem", "ipsum", "dolore");
            Assert.True(a.Equals(b));
        }
    }
}
