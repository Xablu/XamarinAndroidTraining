using NUnit.Framework;
using Phoneword.Core;
using Phoneword.UnitTests.Core.Mocks;

namespace Phoneword.UnitTests.Core
{
    [TestFixture]
    public class TestPhoneTranslateViewModel
    {
        MainViewModel appViewModel;
        MockDialer dialer;
        PhoneTranslateViewModel translateViewModel;

        [SetUp]
        public void SetupViewModels()
        {
            dialer = new MockDialer();
            appViewModel = new MainViewModel(dialer);
            translateViewModel = new PhoneTranslateViewModel(appViewModel);
        }

        [Test]
        public void TestNoTranslateOnEmptyText()
        {
            translateViewModel.PhoneNumberText = string.Empty;
            Assert.IsFalse(translateViewModel.TranslateCommand.CanExecute(null));
        }

        [Test]
        public void TestPhoneNumberAllowsForTranslation()
        {
            translateViewModel.PhoneNumberText = "1-855-XAMARIN";
            Assert.IsTrue(translateViewModel.TranslateCommand.CanExecute(null));
        }

        [Test]
        public void TestPhoneNumberTranslates()
        {
            appViewModel.DialledNumbers.Clear();

            translateViewModel.PhoneNumberText = "1-855-XAMARIN";
            translateViewModel.TranslateCommand.Execute(null);
            translateViewModel.CallCommand.Execute(null);

            Assert.IsTrue(dialer.CalledDialer);
            Assert.AreEqual(dialer.LastDialedNumber, "1-855-9262746");

            Assert.IsTrue(appViewModel.DialledNumbers.Count == 1 &&
                appViewModel.DialledNumbers[0] == "1-855-9262746");
        }

        [Test]
        public void TestDialerCalls()
        {
            appViewModel.DialledNumbers.Clear();

            translateViewModel.PhoneNumberText = "1-855-XAMARIN";
            translateViewModel.TranslateCommand.Execute(null);
            translateViewModel.CallCommand.Execute(null);

            Assert.IsTrue(dialer.CalledDialer);
        }

        [Test]
        public void TestLastDialedNumberStores()
        {
            appViewModel.DialledNumbers.Clear();

            translateViewModel.PhoneNumberText = "1-855-XAMARIN";
            translateViewModel.TranslateCommand.Execute(null);
            translateViewModel.CallCommand.Execute(null);

            Assert.AreEqual(dialer.LastDialedNumber, "1-855-9262746");
        }

        [Test]
        public void TestDialedNumbersCountIncrements()
        {
            appViewModel.DialledNumbers.Clear();

            translateViewModel.PhoneNumberText = "1-855-XAMARIN";
            translateViewModel.TranslateCommand.Execute(null);
            translateViewModel.CallCommand.Execute(null);

            Assert.IsTrue(appViewModel.DialledNumbers.Count == 1);
        }

        public void TestViewModelDialedNumbers()
        {
            appViewModel.DialledNumbers.Clear();

            translateViewModel.PhoneNumberText = "1-855-XAMARIN";
            translateViewModel.TranslateCommand.Execute(null);
            translateViewModel.CallCommand.Execute(null);

            Assert.IsTrue(appViewModel.DialledNumbers[0] == "1-855-9262746");
        }
    }
}

