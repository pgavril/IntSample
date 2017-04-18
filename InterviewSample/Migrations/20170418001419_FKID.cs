using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InterviewSample.Migrations
{
    public partial class FKID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Contact_ContactID",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_ContactID",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "ContactID",
                table: "Address",
                newName: "ContactNum");

            migrationBuilder.AddColumn<int>(
                name: "ContactsID",
                table: "Address",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_ContactsID",
                table: "Address",
                column: "ContactsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Contact_ContactsID",
                table: "Address",
                column: "ContactsID",
                principalTable: "Contact",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Contact_ContactsID",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_ContactsID",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "ContactsID",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "ContactNum",
                table: "Address",
                newName: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_Address_ContactID",
                table: "Address",
                column: "ContactID");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Contact_ContactID",
                table: "Address",
                column: "ContactID",
                principalTable: "Contact",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
