using NUnit.Framework;
using Phoneword.Core;
using System;

namespace Phoneword.UnitTests.Core.Mocks
{
    public class MockDialer : IDialer
    {
        public string LastDialedNumber = null;
        public bool CalledDialer = false;

       public bool Dial(string number)
       {
          CalledDialer = true;
          LastDialedNumber = number;
          return true;
       }
    }
}
