using Microsoft.EntityFrameworkCore.Migrations;

namespace SqlModels.Migrations
{
    public partial class Test002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Typelist",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "OrderdetailId",
                table: "Orderdetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateTable(
                name: "TypeGroup",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeGroup", x => x.GroupId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Typelist_GroupId",
                table: "Typelist",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Typelisy_TypeGroup",
                table: "Typelist",
                column: "GroupId",
                principalTable: "TypeGroup",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Typelisy_TypeGroup",
                table: "Typelist");

            migrationBuilder.DropTable(
                name: "TypeGroup");

            migrationBuilder.DropIndex(
                name: "IX_Typelist_GroupId",
                table: "Typelist");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Typelist");

            migrationBuilder.AlterColumn<int>(
                name: "OrderdetailId",
                table: "Orderdetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
