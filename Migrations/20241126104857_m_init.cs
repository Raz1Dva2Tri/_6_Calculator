﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calculator.Migrations
{
    public partial class m_init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DataInputVariants",
                columns: table => new
                {
                    ID_DataInputVariant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Operand_1 = table.Column<double>(type: "double", nullable: false),
                    Operand_2 = table.Column<double>(type: "double", nullable: false),
                    Type_operation = table.Column<int>(type: "int", nullable: false),
                    Result = table.Column<string>(type: "varchar(128)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataInputVariants", x => x.ID_DataInputVariant);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataInputVariants");
        }
    }
}
