using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _01_CafeUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {


        //Adding a field outside of my methods
        //private StreamingContentRepository _streamingRepo;              this field is declared but not initialized
        //private StreamingContent _content;
        [TestInitialize] 
        public void Arrange() //This code will be ran before anything else
        {
            //_streamingRepo = new StreamingContentRepository();
            //_content = new StreamingContent("Midnight Mass", "scary stuff", 4.5, MaturityRating.R, GenreType.Thriller);
        }

        [TestMethod]
        public void TestMethod1()
        {
            //ARRANGE
            //ACT
            //bool wasAdded = _streamingRepo.AddContentToDirectory(_content);
            //ASSERT
            //Assert.IsTrue(wasAdded);
        }
    }
}
