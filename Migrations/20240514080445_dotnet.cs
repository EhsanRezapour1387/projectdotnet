using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectdotnet.Migrations
{
    /// <inheritdoc />
    public partial class dotnet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "image",
                table: "tbl_Offers",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "tbl_Offers",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "tbl_Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Users");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "tbl_Offers",
                newName: "image");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tbl_Offers",
                newName: "id");
        }
    }
}
