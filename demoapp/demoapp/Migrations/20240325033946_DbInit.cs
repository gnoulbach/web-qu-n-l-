using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace demoapp.Migrations
{
    public partial class DbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "exerciseequipment",
                columns: table => new
                {
                    idm = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    quantity = table.Column<int>(type: "integer", nullable: true),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    price = table.Column<int>(type: "integer", nullable: true),
                    note = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("exerciseequipment_pkey", x => x.idm);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    gender = table.Column<bool>(type: "boolean", nullable: true),
                    age = table.Column<int>(type: "integer", nullable: true),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    phone = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    address = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    salary = table.Column<int>(type: "integer", nullable: true),
                    role = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    point = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "workoutpackage",
                columns: table => new
                {
                    idg = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    timestart = table.Column<DateTime>(type: "date", nullable: true),
                    timeend = table.Column<DateTime>(type: "date", nullable: true),
                    price = table.Column<int>(type: "integer", nullable: true),
                    status = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("workoutpackage_pkey", x => x.idg);
                });

            migrationBuilder.CreateTable(
                name: "invoice",
                columns: table => new
                {
                    idhd = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    amount = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("invoice_pkey", x => x.idhd);
                    table.ForeignKey(
                        name: "invoice_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "membercard",
                columns: table => new
                {
                    idt = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    package_id = table.Column<int>(type: "integer", nullable: true),
                    timestart = table.Column<DateTime>(type: "date", nullable: true),
                    timeend = table.Column<DateTime>(type: "date", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("membercard_pkey", x => x.idt);
                    table.ForeignKey(
                        name: "membercard_package_id_fkey",
                        column: x => x.package_id,
                        principalTable: "workoutpackage",
                        principalColumn: "idg",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "membercard_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "invoicedetail",
                columns: table => new
                {
                    idch = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    invoice_id = table.Column<int>(type: "integer", nullable: true),
                    package_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("invoicedetail_pkey", x => x.idch);
                    table.ForeignKey(
                        name: "invoicedetail_invoice_id_fkey",
                        column: x => x.invoice_id,
                        principalTable: "invoice",
                        principalColumn: "idhd",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "invoicedetail_package_id_fkey",
                        column: x => x.package_id,
                        principalTable: "workoutpackage",
                        principalColumn: "idg",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_invoice_user_id",
                table: "invoice",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoicedetail_invoice_id",
                table: "invoicedetail",
                column: "invoice_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoicedetail_package_id",
                table: "invoicedetail",
                column: "package_id");

            migrationBuilder.CreateIndex(
                name: "IX_membercard_package_id",
                table: "membercard",
                column: "package_id");

            migrationBuilder.CreateIndex(
                name: "IX_membercard_user_id",
                table: "membercard",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exerciseequipment");

            migrationBuilder.DropTable(
                name: "invoicedetail");

            migrationBuilder.DropTable(
                name: "membercard");

            migrationBuilder.DropTable(
                name: "invoice");

            migrationBuilder.DropTable(
                name: "workoutpackage");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
