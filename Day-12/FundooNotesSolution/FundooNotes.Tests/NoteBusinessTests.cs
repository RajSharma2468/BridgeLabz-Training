using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using FundooNotes.Business;
using FundooNotes.Repository;
using FundooNotes.Model.Entities;
using FundooNotes.Model.DTOs.Request;
using FundooNotes.Model.Exceptions;

namespace FundooNotes.Tests
{
    // Contains unit tests for NoteBusiness
    [TestClass]
    public class NoteBusinessTests
    {
        private Mock<INoteRepository> _mockRepository;
        private IMemoryCache _cache;
        private NoteBusiness _business;

        // Runs before every test
        [TestInitialize]
        public void Setup()
        {
            _mockRepository = new Mock<INoteRepository>();
            _cache = new MemoryCache(new MemoryCacheOptions());
            _business = new NoteBusiness(_mockRepository.Object, _cache);
        }

        // Tests that valid note creation succeeds
        [TestMethod]
        public void CreateNote_ValidTitle_CallsRepositoryAdd()
        {
            var dto = new CreateNoteRequestDTO { Title = "Test Note", UserId = 1 };
            _business.CreateNote(dto);
            _mockRepository.Verify(r => r.Add(It.IsAny<Note>()), Times.Once);
        }

        // Tests that empty title throws validation exception
        [TestMethod]
        public void CreateNote_EmptyTitle_ThrowsValidationException()
        {
            var dto = new CreateNoteRequestDTO { Title = "", UserId = 1 };
            Assert.ThrowsException<ValidationException>(() => _business.CreateNote(dto));
        }

        // Tests that trashing a non-existent note throws exception
        [TestMethod]
        public void TrashNote_NoteNotFound_ThrowsException()
        {
            _mockRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns((Note)null);
            Assert.ThrowsException<UserNotFoundException>(() => _business.TrashNote(99));
        }

        // Tests that trash flag toggles correctly
        [TestMethod]
        public void TrashNote_ValidId_TogglesFlag()
        {
            var note = new Note { NoteId = 1, IsTrashed = false };
            _mockRepository.Setup(r => r.GetById(1)).Returns(note);
            _business.TrashNote(1);
            Assert.IsTrue(note.IsTrashed);
            _mockRepository.Verify(r => r.Update(note), Times.Once);
        }
    }
}