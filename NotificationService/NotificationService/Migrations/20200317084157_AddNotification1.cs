using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NotificationService.Migrations
{
    public partial class AddNotification1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Targets_");

            migrationBuilder.AddColumn<string>(
                name: "email_destination",
                table: "Logs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "target",
                table: "Logs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email_destination",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "target",
                table: "Logs");

            migrationBuilder.CreateTable(
                name: "Targets_",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NotificationLogs_id = table.Column<int>(type: "integer", nullable: true),
                    email_destination = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Targets_", x => x.id);
                    table.ForeignKey(
                        name: "FK_Targets__Logs_NotificationLogs_id",
                        column: x => x.NotificationLogs_id,
                        principalTable: "Logs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Targets__NotificationLogs_id",
                table: "Targets_",
                column: "NotificationLogs_id");
        }
    }
}
