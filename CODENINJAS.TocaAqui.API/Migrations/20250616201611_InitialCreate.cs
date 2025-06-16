using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace CODENINJAS.TocaAqui.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "event",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    promoter_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    time = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    publish_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    location = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    image_url = table.Column<string>(type: "longtext", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    soundcheck_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    soundcheck_time = table.Column<TimeSpan>(type: "time(6)", nullable: true),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    admin_name = table.Column<string>(type: "longtext", nullable: false),
                    admin_id = table.Column<int>(type: "int", nullable: true),
                    admin_contact = table.Column<string>(type: "longtext", nullable: false),
                    requirements = table.Column<string>(type: "longtext", nullable: false),
                    description = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    payment = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    duration = table.Column<int>(type: "int", nullable: true),
                    genre = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    equipment = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_event", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "varchar(320)", maxLength: 320, nullable: false),
                    password_hash = table.Column<string>(type: "longtext", nullable: false),
                    role = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    genre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                    image_url = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "invitation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    event_id = table.Column<int>(type: "int", nullable: false),
                    event_name = table.Column<string>(type: "longtext", nullable: false),
                    event_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    event_location = table.Column<string>(type: "longtext", nullable: false),
                    event_image_url = table.Column<string>(type: "longtext", nullable: false),
                    promoter_id = table.Column<int>(type: "int", nullable: false),
                    promoter_name = table.Column<string>(type: "longtext", nullable: false),
                    artist_id = table.Column<int>(type: "int", nullable: false),
                    artist_name = table.Column<string>(type: "longtext", nullable: false),
                    message = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    status = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_invitation", x => x.id);
                    table.ForeignKey(
                        name: "FK_invitation_event_event_id",
                        column: x => x.event_id,
                        principalTable: "event",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contract",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    event_application_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    content = table.Column<string>(type: "varchar(5000)", maxLength: 5000, nullable: false),
                    signature = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: true),
                    signed_date = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contract", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "event_applicant",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    event_id = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    application_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    contract_signed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    rider_uploaded = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    is_invited = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    contract_id = table.Column<int>(type: "int", nullable: true),
                    rider_technical_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_event_applicant", x => x.id);
                    table.ForeignKey(
                        name: "fk_event_applicant_contract_contract_id",
                        column: x => x.contract_id,
                        principalTable: "contract",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_event_applicant_event_event_id",
                        column: x => x.event_id,
                        principalTable: "event",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rider_technical",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    event_application_id = table.Column<int>(type: "int", nullable: false),
                    content = table.Column<string>(type: "varchar(5000)", maxLength: 5000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_rider_technical", x => x.id);
                    table.ForeignKey(
                        name: "fk_rider_technical_event_applicant_event_application_id",
                        column: x => x.event_application_id,
                        principalTable: "event_applicant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "ix_contract_event_application_id",
                table: "contract",
                column: "event_application_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_event_applicant_contract_id",
                table: "event_applicant",
                column: "contract_id");

            migrationBuilder.CreateIndex(
                name: "ix_event_applicant_event_id",
                table: "event_applicant",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "ix_event_applicant_rider_technical_id",
                table: "event_applicant",
                column: "rider_technical_id");

            migrationBuilder.CreateIndex(
                name: "IX_invitation_event_id",
                table: "invitation",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "ix_rider_technical_event_application_id",
                table: "rider_technical",
                column: "event_application_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_contract_event_applicant_event_application_id",
                table: "contract",
                column: "event_application_id",
                principalTable: "event_applicant",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_event_applicant_rider_technical_rider_technical_id",
                table: "event_applicant",
                column: "rider_technical_id",
                principalTable: "rider_technical",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_contract_event_applicant_event_application_id",
                table: "contract");

            migrationBuilder.DropForeignKey(
                name: "fk_rider_technical_event_applicant_event_application_id",
                table: "rider_technical");

            migrationBuilder.DropTable(
                name: "invitation");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "event_applicant");

            migrationBuilder.DropTable(
                name: "contract");

            migrationBuilder.DropTable(
                name: "event");

            migrationBuilder.DropTable(
                name: "rider_technical");
        }
    }
}
