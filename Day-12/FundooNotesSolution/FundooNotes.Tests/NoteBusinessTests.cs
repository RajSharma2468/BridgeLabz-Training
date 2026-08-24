using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

using FundooNotes.Business;
using FundooNotes.Repository;
using FundooNotes.Model.Entities;
using FundooNotes.Model.DTOs.Request;
using FundooNotes.Model.Exceptions;

namespace FundooNotes.Tests
{
    // Contains unit tests for NoteBusiness.
    [TestClass]
    public class NoteBusinessTests
    {
        // Mock repository.
        // Actual database will NOT be used.
        private Mock<INoteRepository> _mockRepository;

        // Business object under test.
        private NoteBusiness _business;


        // Runs before every test.
        [TestInitialize]
        public void Setup()
        {
            // Create fake repository.
            _mockRepository =
                new Mock<INoteRepository>();

            // Inject mocked repository
            // into Business layer.
            _business =
                new NoteBusiness(
                    _mockRepository.Object);
        }


        // ------------------------------------------------
        // TEST 1
        // Valid note should call repository Add().
        // ------------------------------------------------
        [TestMethod]
        public void CreateNote_ValidTitle_CallsRepositoryAdd()
        {
            // Arrange
            var dto =
                new CreateNoteRequestDTO
                {
                    Title = "Test Note",
                    UserId = 1
                };

            // Act
            _business.CreateNote(dto);

            // Assert
            _mockRepository.Verify(
                r => r.Add(
                    It.IsAny<Note>()),
                Times.Once);
        }


        // ------------------------------------------------
        // TEST 2
        // Empty title should throw exception.
        // ------------------------------------------------
        [TestMethod]
        public void CreateNote_EmptyTitle_ThrowsValidationException()
        {
            // Arrange
            var dto =
                new CreateNoteRequestDTO
                {
                    Title = "",
                    UserId = 1
                };

            // Act + Assert
            Assert.ThrowsException<
                ValidationException>(
                () =>
                    _business.CreateNote(dto));
        }


        // ------------------------------------------------
        // TEST 3
        // Non-existing note should throw exception.
        // ------------------------------------------------
        [TestMethod]
        public void TrashNote_NoteNotFound_ThrowsException()
        {
            // Arrange
            _mockRepository
                .Setup(
                    r => r.GetById(
                        It.IsAny<int>()))
                .Returns((Note)null);

            // Act + Assert
            Assert.ThrowsException<
                UserNotFoundException>(
                () =>
                    _business.TrashNote(99));
        }


        // ------------------------------------------------
        // TEST 4
        // Trash flag should change.
        // ------------------------------------------------
        [TestMethod]
        public void TrashNote_ValidId_TogglesFlag()
        {
            // Arrange
            var note =
                new Note
                {
                    NoteId = 1,
                    IsTrashed = false
                };

            _mockRepository
                .Setup(
                    r => r.GetById(1))
                .Returns(note);

            // Act
            _business.TrashNote(1);

            // Assert
            Assert.IsTrue(
                note.IsTrashed);

            // Verify repository update.
            _mockRepository.Verify(
                r => r.Update(note),
                Times.Once);
        }
    }
}
