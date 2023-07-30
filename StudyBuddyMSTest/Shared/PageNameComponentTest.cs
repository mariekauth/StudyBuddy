using Bunit;
using StudyBuddy.Shared;

namespace StudyBuddyMSTest.Shared
{
    [TestClass]
    internal class PageNameComponentTest : TestContextWrapper
    {
        [TestInitialize]
        public void Setup()
        {
            TestContext = new Bunit.TestContext();
        }

        [TestCleanup]
        public void TearDown() => TestContext?.Dispose();

        [TestMethod]
        public void PageNameComponentRendorsCorrectly()
        {
            var cut = RenderComponent<PageNameComponent>(parameters => parameters.Add(p => p.Value, "Parameter Value"));
            var ele = cut.Find("h1");
            ele?.MarkupMatches("<h1>Parameter Value</h1>");
        }
    }
}
