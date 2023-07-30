using Bunit;
using StudyBuddy.Pages;

namespace StudyBuddyMSTest
{
    [TestClass]
    public class CounterTest : TestContextWrapper
    {
        [TestInitialize]
        public void Setup() => TestContext = new Bunit.TestContext();

        [TestCleanup]
        public void TearDown() => TestContext?.Dispose();

        [TestMethod]
        public void CounterHasH1WithCounter()
        {
            // Setup
            var cut = RenderComponent<Counter>();

            // Act
            var ele = cut.Find("h1");

            // Assert
            ele.MarkupMatches("<h1>Counter</h1>");
        }

        [TestMethod]
        public void CounterRendersCurrentCount()
        {
            // Setup
            var cut = RenderComponent<Counter>();

            // Act
            var ele = GetCurrentCountElement(cut);

            // Assert
            ele?.MarkupMatches("<p role=\"status\">Current count: 0</p>");
        }

        [TestMethod]
        public void CounterHasIncrementButton()
        {
            // Setup
            var cut = RenderComponent<Counter>();

            // Act
            var incrementButton = GetIncrementButton(cut);

            // Assert
            Assert.IsNotNull(incrementButton);
        }

        [TestMethod]
        public void CounterIncrementsCorrectlyWhenClicked()
        {
            // Setup
            var cut = RenderComponent<Counter>();

            // Act
            var ele = GetIncrementButton(cut);
            ele?.Click();

            // Assert
            cut.Find("p").MarkupMatches("<p role=\"status\">Current count: 1</p>");
        }

        [TestMethod]
        public void CounterIncrementsCorrectlyWhenClickedThreeTimes()
        {
            // Setup
            var cut = RenderComponent<Counter>();

            // Act
            var ele = GetIncrementButton(cut);

            for(var i = 0; i<3; i++)
            {
                ele?.Click();
            }

            // Assert
            cut.Find("p").MarkupMatches("<p role=\"status\">Current count: 3</p>");
        }

        private static AngleSharp.Dom.IElement? GetIncrementButton(IRenderedComponent<Counter> cut)
        {
            return cut.Find("button.btn-primary");
        }

        private static AngleSharp.Dom.IElement? GetCurrentCountElement(IRenderedComponent<Counter> cut)
        {
            return cut.Find("p");
        }
    }
}
