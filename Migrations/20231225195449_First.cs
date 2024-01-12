using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTRS.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "passenger",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    phone_n = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passenger", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "trip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    trip_dist = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    S_date = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    E_date = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_trip_admin_AdminId",
                        column: x => x.AdminId,
                        principalTable: "admin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "bus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    caption_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    n_ofSeat = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    FK_tripID = table.Column<int>(type: "int", nullable: false),
                    FK_AdminID = table.Column<int>(type: "int", nullable: false),
                    fk_ID_admin = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_bus_admin_FK_AdminID",
                        column: x => x.FK_AdminID,
                        principalTable: "admin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bus_trip_fk_ID_admin",
                        column: x => x.fk_ID_admin,
                        principalTable: "trip",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_bus_trip_FK_tripID",
                        column: x => x.FK_tripID,
                        principalTable: "trip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "passenger_Trips",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FK_PassengerID = table.Column<int>(type: "int", nullable: false),
                    passesngerID = table.Column<int>(type: "int", nullable: false),
                    FK_TripID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passenger_Trips", x => x.ID);
                    table.ForeignKey(
                        name: "FK_passenger_Trips_passenger_FK_PassengerID",
                        column: x => x.FK_PassengerID,
                        principalTable: "passenger",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_passenger_Trips_trip_FK_TripID",
                        column: x => x.FK_TripID,
                        principalTable: "trip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bus_FK_AdminID",
                table: "bus",
                column: "FK_AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_bus_fk_ID_admin",
                table: "bus",
                column: "fk_ID_admin");

            migrationBuilder.CreateIndex(
                name: "IX_bus_FK_tripID",
                table: "bus",
                column: "FK_tripID");

            migrationBuilder.CreateIndex(
                name: "IX_passenger_Trips_FK_PassengerID",
                table: "passenger_Trips",
                column: "FK_PassengerID");

            migrationBuilder.CreateIndex(
                name: "IX_passenger_Trips_FK_TripID",
                table: "passenger_Trips",
                column: "FK_TripID");

            migrationBuilder.CreateIndex(
                name: "IX_trip_AdminId",
                table: "trip",
                column: "AdminId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bus");

            migrationBuilder.DropTable(
                name: "passenger_Trips");

            migrationBuilder.DropTable(
                name: "passenger");

            migrationBuilder.DropTable(
                name: "trip");

            migrationBuilder.DropTable(
                name: "admin");
        }
    }
}
