using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InterviewSample.Migrations
{
    public partial class FKBack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Contact_ContactsID",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "ContactNum",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "ContactsID",
                table: "Address",
                newName: "ContactID");

            migrationBuilder.RenameIndex(
                name: "IX_Address_ContactsID",
                table: "Address",
                newName: "IX_Address_ContactID");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Contact_ContactID",
                table: "Address",
                column: "ContactID",
                principalTable: "Contact",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Contact_ContactID",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "ContactID",
                table: "Address",
                newName: "ContactsID");

            migrationBuilder.RenameIndex(
                name: "IX_Address_ContactID",
                table: "Address",
                newName: "IX_Address_ContactsID");

            migrationBuilder.AddColumn<int>(
                name: "ContactNum",
                table: "Address",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Contact_ContactsID",
                table: "Address",
                column: "ContactsID",
                principalTable: "Contact",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
