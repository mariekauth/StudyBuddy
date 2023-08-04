using Bunit;
using StudyBuddy.Pages;
using StudyBuddy.Shared;

namespace StudyBuddyMSTest.Pages
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
            var ele = GetRenderedPageLabel(cut);

            // Assert
            ele?.MarkupMatches("<h1 class=\"page-label\">Counter</h1>");
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
            var button = GetIncrementButton(cut);
            button?.Click();

            var currentCount = GetCurrentCountElement(cut);

            // Assert
            currentCount?.MarkupMatches("<p role=\"status\">Current count: 1</p>");
        }

        [TestMethod]
        public void CounterIncrementsCorrectlyWhenClickedThreeTimes()
        {
            // Setup
            var cut = RenderComponent<Counter>();

            // Act
            var ele = GetIncrementButton(cut);

            for (var i = 0; i < 3; i++)
            {
                ele?.Click();
            }

            // Assert
            cut.Find("p").MarkupMatches("<p role=\"status\">Current count: 3</p>");
        }

        [TestMethod]
        public void CounterIncrementsCorrectlyWhenIncrementByIs2AndClickedThreeTimes()
        {
            // Setup
            var cut = RenderComponent<Counter>(
                    parameters => parameters
                    .Add(p => p.Action, "IncrementBy") 
                    .Add(p => p.Value, "2")
                );

            // Act
            var ele = GetIncrementButton(cut);

            for (var i = 0; i < 3; i++)
            {
                ele?.Click();
            }

            // Assert
            cut.Find("p").MarkupMatches("<p role=\"status\">Current count: 6</p>");
        }

        [TestMethod]
        public void CounterIncrementsCorrectlyWhenIncrementByIs5AndClickedThreeTimes()
        {
            // Setup
            var cut = RenderComponent<Counter>(
                    parameters => parameters
                    .Add(p => p.Action, "IncrementBy")
                    .Add(p => p.Value, "5")
                );

            // Act
            var ele = GetIncrementButton(cut);

            for (var i = 0; i < 3; i++)
            {
                ele?.Click();
            }

            // Assert
            cut.Find("p").MarkupMatches("<p role=\"status\">Current count: 15</p>");
        }

        [TestMethod]
        public void CounterLabelRendersCorrectlyWhenIncrementByIs5()
        {
            // Setup
            var cut = RenderComponent<Counter>(
                    parameters => parameters
                    .Add(p => p.Action, "IncrementBy")
                    .Add(p => p.Value, "5")
                );

            // Act
            var ele = GetRenderedPageLabel(cut);

            // Assert
            ele?.MarkupMatches("<h1 class=\"page-label\">Count By 5</h1>");
        }

        [TestMethod]
        public void CounterLabelRendersCorrectlyWhenActionIsFibonacci()
        {
            // Setup
            var cut = RenderComponent<Counter>(
                    parameters => parameters
                    .Add(p => p.Action, "Fibonacci")
                    .Add(p => p.Value, "1")
                );

            // Act
            var ele = GetRenderedPageLabel(cut);

            // Assert
            ele?.MarkupMatches("<h1 class=\"page-label\">Fibonacci Counter</h1>");
        }

        [TestMethod]
        public void CounterIncrementsCorrectlyWhenActionIsFibonacciAndNotClicked()
        {
            // Setup
            var cut = RenderComponent<Counter>(
                    parameters => parameters
                    .Add(p => p.Action, "Fibonacci")
                );

            // Act


            // Assert
            cut.Find("p").MarkupMatches("<p role=\"status\">Current count: 0</p>");
        }

        [TestMethod]
        public void CounterIncrementsCorrectlyWhenActionIsFibonacciAndClickedOnce()
        {
            // Setup
            var cut = RenderComponent<Counter>(
                    parameters => parameters
                    .Add(p => p.Action, "Fibonacci")
                );
            var timesClicked = 1;

            // Act
            var ele = GetIncrementButton(cut);

            for (var i = 0; i < timesClicked; i++)
            {
                ele?.Click();
            }

            // Assert
            cut.Find("p").MarkupMatches("<p role=\"status\">Current count: 1</p>");
        }

        [TestMethod]
        public void CounterIncrementsCorrectlyWhenActionIsFibonacciAndClickedTwice()
        {
            // Setup
            var cut = RenderComponent<Counter>(
                    parameters => parameters
                    .Add(p => p.Action, "Fibonacci")
                );
            var timesClicked = 2;

            // Act
            var ele = GetIncrementButton(cut);

            for (var i = 0; i < timesClicked; i++)
            {
                ele?.Click();
            }

            // Assert
            cut.Find("p").MarkupMatches("<p role=\"status\">Current count: 1</p>");
        }

        [TestMethod]
        public void CounterIncrementsCorrectlyWhenActionIsFibonacciAndClickedThreeTimes()
        {
            // Setup
            var cut = RenderComponent<Counter>(
                    parameters => parameters
                    .Add(p => p.Action, "Fibonacci")
                );
            var timesClicked = 3;

            // Act
            var ele = GetIncrementButton(cut);

            for (var i = 0; i < timesClicked; i++)
            {
                ele?.Click();
            }

            // Assert
            cut.Find("p").MarkupMatches("<p role=\"status\">Current count: 2</p>");
        }

        [TestMethod]
        public void CounterIncrementsCorrectlyWhenActionIsFibonacciAndClickedFourTimes()
        {
            // Setup
            var cut = RenderComponent<Counter>(
                    parameters => parameters
                    .Add(p => p.Action, "Fibonacci")
                );
            var timesClicked = 4;

            // Act
            var ele = GetIncrementButton(cut);

            for (var i = 0; i < timesClicked; i++)
            {
                ele?.Click();
            }

            // Assert
            cut.Find("p").MarkupMatches("<p role=\"status\">Current count: 3</p>");
        }

        [TestMethod]
        public void CounterIncrementsCorrectlyWhenActionIsFibonacciAndClickedFiveTimes()
        {
            // Setup
            var cut = RenderComponent<Counter>(
                    parameters => parameters
                    .Add(p => p.Action, "Fibonacci")
                );
            var timesClicked = 5;

            // Act
            var ele = GetIncrementButton(cut);

            for (var i = 0; i < timesClicked; i++)
            {
                ele?.Click();
            }

            // Assert
            cut.Find("p").MarkupMatches("<p role=\"status\">Current count: 5</p>");
        }

        [TestMethod]
        public void CounterIncrementsCorrectlyWhenActionIsFibonacciAndClickedSixTimes()
        {
            // Setup
            var cut = RenderComponent<Counter>(
                    parameters => parameters
                    .Add(p => p.Action, "Fibonacci")
                );
            var timesClicked = 6;

            // Act
            var ele = GetIncrementButton(cut);

            for (var i = 0; i < timesClicked; i++)
            {
                ele?.Click();
            }

            // Assert
            cut.Find("p").MarkupMatches("<p role=\"status\">Current count: 8</p>");
        }

        [TestMethod]
        public void CounterIncrementsCorrectlyWhenActionIsFibonacciAndClickedSevenTimes()
        {
            // Setup
            var cut = RenderComponent<Counter>(
                    parameters => parameters
                    .Add(p => p.Action, "Fibonacci")
                );
            var timesClicked = 7;

            // Act
            var ele = GetIncrementButton(cut);

            for (var i = 0; i < timesClicked; i++)
            {
                ele?.Click();
            }

            // Assert
            cut.Find("p").MarkupMatches("<p role=\"status\">Current count: 13</p>");
        }

        [TestMethod]
        public void CounterIncrementsCorrectlyWhenActionIsFibonacciAndClickedEightTimes()
        {
            // Setup
            var cut = RenderComponent<Counter>(
                    parameters => parameters
                    .Add(p => p.Action, "Fibonacci")
                );
            var timesClicked = 8;

            // Act
            var ele = GetIncrementButton(cut);

            for (var i = 0; i < timesClicked; i++)
            {
                ele?.Click();
            }

            // Assert
            cut.Find("p").MarkupMatches("<p role=\"status\">Current count: 21</p>");
        }

        [TestMethod]
        public void CounterIncrementsCorrectlyWhenActionIsFibonacciAndClickedNineTimes()
        {
            // Setup
            var cut = RenderComponent<Counter>(
                    parameters => parameters
                    .Add(p => p.Action, "Fibonacci")
                );
            var timesClicked = 9;

            // Act
            var ele = GetIncrementButton(cut);

            for (var i = 0; i < timesClicked; i++)
            {
                ele?.Click();
            }

            // Assert
            cut.Find("p").MarkupMatches("<p role=\"status\">Current count: 34</p>");
        }

        [TestMethod]
        public void CounterIncrementsCorrectlyWhenActionIsFibonacciAndClickedTenTimes()
        {
            // Setup
            var cut = RenderComponent<Counter>(
                    parameters => parameters
                    .Add(p => p.Action, "Fibonacci")
                );
            var timesClicked = 10;

            // Act
            var ele = GetIncrementButton(cut);

            for (var i = 0; i < timesClicked; i++)
            {
                ele?.Click();
            }

            // Assert
            cut.Find("p").MarkupMatches("<p role=\"status\">Current count: 55</p>");
        }

        [TestMethod]
        public void CounterIncrementsCorrectlyWhenActionIsFibonacciAndClickedElevenTimes()
        {
            // Setup
            var cut = RenderComponent<Counter>(
                    parameters => parameters
                    .Add(p => p.Action, "Fibonacci")
                );
            var timesClicked = 11;

            // Act
            var ele = GetIncrementButton(cut);

            for (var i = 0; i < timesClicked; i++)
            {
                ele?.Click();
            }

            // Assert
            cut.Find("p").MarkupMatches("<p role=\"status\">Current count: 89</p>");
        }

        [TestMethod]
        public void HasCompenentPageName()
        {
            var cut = RenderComponent<Counter>();
            Assert.IsTrue(cut.HasComponent<PageLabelComponent>());
        }

        public static AngleSharp.Dom.IElement? GetRenderedPageLabel(IRenderedComponent<Counter> cut) => cut.Find("h1.page-label");

        private static AngleSharp.Dom.IElement? GetIncrementButton(IRenderedComponent<Counter> cut)
        {
            return cut.Find(".btn-counter");
        }

        private static AngleSharp.Dom.IElement? GetCurrentCountElement(IRenderedComponent<Counter> cut)
        {
            return cut.Find("p");
        }
    }
}
