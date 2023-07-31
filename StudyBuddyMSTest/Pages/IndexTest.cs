using Bunit;
using StudyBuddy.Shared;

namespace StudyBuddyMSTest.Pages
{
    [TestClass]
    public class IndexTest : TestContextWrapper
    {
        [TestInitialize]
        public void Setup()
        {
            TestContext = new Bunit.TestContext();
        }

        [TestCleanup]
        public void TearDown() => TestContext?.Dispose();

        [TestMethod]
        public void HasSurveyPromptCompenen()
        {
            var cut = RenderComponent<StudyBuddy.Pages.Index>();
            Assert.IsTrue(cut.HasComponent<SurveyPrompt>());
        }

        [TestMethod]
        public void HasPageLabelComponent()
        {
            var cut = RenderComponent<StudyBuddy.Pages.Index>();
            Assert.IsTrue(cut.HasComponent<PageLabelComponent>());
        }

        [TestMethod]
        public void HasTagLineComponent()
        {
            var cut = RenderComponent<StudyBuddy.Pages.Index>();
            Assert.IsTrue(cut.HasComponent<TagLineComponent>());
        }
    }
}
