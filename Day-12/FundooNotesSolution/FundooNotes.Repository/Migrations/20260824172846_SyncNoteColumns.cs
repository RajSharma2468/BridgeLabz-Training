using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FundooNotes.Repository.Migrations
{
    /// <inheritdoc />
    public partial class SyncNoteColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Label and ReminderDateTime already exist
            // in the database because they were added manually.
            // Therefore, no database change is required here.
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Do not remove the existing columns.
        }
    }
}