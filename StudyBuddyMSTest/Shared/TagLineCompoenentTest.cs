using Bunit;
using StudyBuddy.Shared;

namespace StudyBuddyMSTest.Shared
{
    [TestClass]
    public class TagLinelComponentTest : TestContextWrapper
    {
        [TestInitialize]
        public void Setup()
        {
            TestContext = new Bunit.TestContext();
        }

        [TestCleanup]
        public void TearDown() => TestContext?.Dispose();

        [TestMethod]
        public void TagLineComponentRendorsCorrectly()
        {
            var cut = RenderComponent<TagLineComponent>(parameters => parameters.Add(p => p.Value, "Parameter Value"));
            var ele = cut.Find("span.tag-line");
            ele?.MarkupMatches("<span class=\"tag-line\">Parameter Value</span>");
        }
    }
}
