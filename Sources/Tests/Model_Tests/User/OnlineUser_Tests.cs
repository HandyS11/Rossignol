﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Model.User;
using Model;
using System.Net.Mail;

namespace Model_Tests.User
{
    public class OnlineUser_Tests
    {
        [Fact]
        public void EmailSetter_ShouldAssignValue()
        {
            AbstractUser user = new OnlineUser("kaman.zok@organs.com");
            Assert.Equal("kaman.zok@organs.com", user.email.Address);
        }

        [Theory]
        [InlineData(true, "sarmat@torba.com", "sarmat@torba.com")]
        [InlineData(true, "Sarmat@torba.com", "sarmat@torba.com")]
        [InlineData(false, "sortob@torba.com", "sarmat@torba.com")]
        public void UserEquality_ShouldBeEqual(bool shouldBeEqual, string email1, string email2)
        {
            AbstractUser user1 = new OnlineUser(email1);
            AbstractUser user2 = new OnlineUser(email2);
            Assert.Equal(shouldBeEqual, (((IEquatable<AbstractUser>)user1).Equals(user2)));
        }

        /// <summary>
        /// Test if class constructor throws an exception or not
        /// </summary>
        /// <param name="login"></param>
        /// <param name="app"></param>
        /// <param name="note"></param>
        /// <param name="noteSuccessExpected"></param>
        [Theory]
        [InlineData(false, "sarmat@torba.com")]
        [InlineData(false, "kon@foxmail.cn")]
        [InlineData(true, "pete@totallyreal")]
        [InlineData(true, "zabuk@machina/../../index.php")]
        [InlineData(true, "grineerzrodak.skp")]
        public void Constructor_ShouldAssignValuesOrThrow(bool shouldThrow,string email)
        {
            try
            {
            AbstractUser user = new OnlineUser(email);
            Assert.Equal(email, user.email.Address);

            }
            catch
            {
                Assert.True(shouldThrow);
            }
        }
    }
}