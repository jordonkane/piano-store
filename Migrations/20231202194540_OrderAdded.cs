using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pianostore.Migrations
{
    /// <inheritdoc />
    public partial class OrderAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OrderPlaced = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Detail", "ImageUrl", "Name", "Price" },
                values: new object[] { "Standard size, 88-key model of the ARIUS digital piano featuring weighted keyboard. With Yamaha's CFX concert grand piano sound as a built-in Voice, experience a luxuriously expressive playing feel with the GH3 keyboard. Includes newly equipped ear-friendly functions, and compatibility with Yamaha’s Smart Pianist app.", "https://www.yamaha.com/us/pianos/images/YDP165B.jpg", "Yamaha YDP-165", 2399m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Detail", "ImageUrl", "Name", "Price" },
                values: new object[] { "The flagship CSP-295GP features a luxurious, elegant grand piano shape with GrandTouch™ pedals that recreate the precise control of an acoustic grand piano.", "https://www.yamaha.com/yamahavgn/PIM/Images/CSP-295GP_PE_a_0001_7a9db7dbaad1955e30fc818bc64030d7_MEDPROC_.jpg", "Yamaha CSP-295GP", 10999m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Detail", "ImageUrl", "Name", "Price" },
                values: new object[] { "Experience newly sampled Voices of the world-renowned CFX and Bösendorfer Imperial grand pianos, featuring binaural sound, and two new centuries-old Fortepiano Voices that allow you to hear classical music the way their original composers did.", "https://www.yamaha.com/us/pianos/images/CLP-735PE_th.jpg", "Yamaha CLP-735", 3199m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Detail", "ImageUrl", "Name", "Price" },
                values: new object[] { "The flagship model in our P-Series, the P-525 offers authentic grand-piano feel and exquisite sound. Thanks to its range of features and smooth playability, the P-525 is perfectly suited for all levels of players, from beginners to pros. ", "https://www.yamaha.com/us/pianos/images/P-525B_th.jpg", "Yamaha P-525", 1999m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Detail", "ImageUrl", "Name", "Price" },
                values: new object[] { "The Yamaha P Series digital pianos. For those who desire the comfortable feel of an acoustic piano in a practical, lightweight design. The P-225 features the sounds of our premier concert grand piano, the CFX, and this model uses Virtual Resonance Modeling (VRM) Lite technology to replicate the expressive moment-by-moment tonal changes that occur in a real grand piano. Whether you are an advanced piano player or a serious beginner looking to learn, the P-225 is the perfect choice.", "https://www.yamaha.com/us/pianos/images/P-225B.jpg", "Yamaha P-225", 999m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Detail", "ImageUrl", "Name", "Price" },
                values: new object[] { "Precise, ultra-responsive touch, clear, full-bodied tone and a reputation for reliability have made U Series pianos the choice of professional musicians, conservatories, teachers, students and music lovers, the world over. Add to that our legendary attention to every detail of every piano, and it’s no surprise that the U Series has been the world’s most popular upright for over half a century.", "https://www.yamaha.com/us/pianos/images/U1-1-c6f7e2c3.jpg", "Yamaha U1 Upright", 17999m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Detail", "ImageUrl", "Name", "Price" },
                values: new object[] { "CX pianos have been redesigned with many of the innovations of our flagship CFX to give artists a more versatile tonal palette while still maintaining the bright, percussive sound that has helped make C series pianos the most recorded in history.", "https://www.yamaha.com/us/pianos/images/c7x.jpg", "Yamaha C7X Grand", 82999m });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Detail", "ImageUrl", "Name", "Price" },
                values: new object[] { "Some details", "", "Piano 1", 15m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Detail", "ImageUrl", "Name", "Price" },
                values: new object[] { "Some details", "", "Piano 2", 15m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Detail", "ImageUrl", "Name", "Price" },
                values: new object[] { "Some details", "", "Piano 3", 15m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Detail", "ImageUrl", "Name", "Price" },
                values: new object[] { "Some details", "", "Piano 4", 15m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Detail", "ImageUrl", "Name", "Price" },
                values: new object[] { "Some details", "", "Piano 5", 15m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Detail", "ImageUrl", "Name", "Price" },
                values: new object[] { "Some details", "", "Piano 6", 15m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Detail", "ImageUrl", "Name", "Price" },
                values: new object[] { "Some details", "", "Piano 7", 15m });
        }
    }
}
