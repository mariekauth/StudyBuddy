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
        public void HasCompenenSurveyPrompt()
        {
            var cut = RenderComponent<StudyBuddy.Pages.Index>();
            Assert.IsTrue(cut.HasComponent<SurveyPrompt>());
        }
    }
}
