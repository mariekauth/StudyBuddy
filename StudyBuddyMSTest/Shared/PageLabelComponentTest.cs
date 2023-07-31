using Bunit;
using StudyBuddy.Shared;
using System.Reflection.Emit;

namespace StudyBuddyMSTest.Shared
{
    [TestClass]
    public class PageLabelComponentTest : TestContextWrapper
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
            var cut = RenderComponent<PageLabelComponent>(parameters => parameters.Add(p => p.Value, "Parameter Value"));
            var ele = cut.Find("h1.page-label");
            ele?.MarkupMatches("<h1 class=\"page-label\">Parameter Value</h1>");
        }
    }
}
