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
        public void AddContentToDirectory_Test()
        {
            //ARRANGE
            //ACT
            //bool wasAdded = _streamingRepo.AddContentToDirectory(_content);    As a developer I want this to return true
            //ASSERT
            //Assert.IsTrue(wasAdded);
            //Assert.IsNotNull(_content);
        }

        [TestMethod]
        public void UpdateExistingContent_Test() // updating _content to see if it returns true
        {
            //_content2 = new StreamingContent("Elf", "crazy singing human that thinks he is an elf", 5.0, MaturityRating.PG, GenreType.Comedy);
            //bool wasFound = _streamingReop.UpdateExistingContent(_content.Title, _content2);
            //Assert.IsTrue(wasFound);
        }
    }
}
