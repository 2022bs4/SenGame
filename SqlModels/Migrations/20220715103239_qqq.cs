using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SqlModels.Migrations
{
    public partial class qqq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyGame_AspNetUsers1",
                table: "MyGame");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_AspNetUsers1",
                table: "ShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Game",
                table: "ShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyGame",
                table: "MyGame");

            migrationBuilder.DropIndex(
                name: "IX_MyGame_UserId",
                table: "MyGame");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MyGame");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ShoppingCart",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "ShoppingCart",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddTime",
                table: "ShoppingCart",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingCartId",
                table: "ShoppingCart",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "MyGame",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyGame",
                table: "MyGame",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MyGame_UserId",
                table: "MyGame",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MyGame_AspNetUsers1",
                table: "MyGame",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_AspNetUsers1",
                table: "ShoppingCart",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Game",
                table: "ShoppingCart",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyGame_AspNetUsers1",
                table: "MyGame");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_AspNetUsers1",
                table: "ShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCart_Game",
                table: "ShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyGame",
                table: "MyGame");

            migrationBuilder.DropIndex(
                name: "IX_MyGame_UserId",
                table: "MyGame");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MyGame");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ShoppingCart",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "ShoppingCart",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddTime",
                table: "ShoppingCart",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShoppingCartId",
                table: "ShoppingCart",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MyGame",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyGame",
                table: "MyGame",
                column: "MyGameId");

            migrationBuilder.CreateIndex(
                name: "IX_MyGame_UserId",
                table: "MyGame",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MyGame_AspNetUsers1",
                table: "MyGame",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_AspNetUsers1",
                table: "ShoppingCart",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCart_Game",
                table: "ShoppingCart",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
