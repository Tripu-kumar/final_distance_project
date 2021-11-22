using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace distanceapi.Migrations
{
    public partial class dist_tbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GetDistances",
                columns: table => new
                {
                    distance_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    from_loc_lat = table.Column<float>(type: "real", nullable: false),
                    from_loc_lng = table.Column<float>(type: "real", nullable: false),
                    to_location_lat = table.Column<float>(type: "real", nullable: false),
                    to_location_lng = table.Column<float>(type: "real", nullable: false),
                    dist = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetDistances", x => x.distance_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GetDistances");
        }
    }
}
