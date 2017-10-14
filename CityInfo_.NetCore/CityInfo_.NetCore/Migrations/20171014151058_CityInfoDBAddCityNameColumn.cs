using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CityInfo_.NetCore.Migrations
{
    public partial class CityInfoDBAddCityNameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Cities",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Cities",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Cities");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Cities",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);
        }
    }
}
