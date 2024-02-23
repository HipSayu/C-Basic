using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppMobileBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class DbInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    IdAccount = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameUser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthOfDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VIP = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.IdAccount);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    IdAlbum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageAlbum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAlbum = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GenreAlbum = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.IdAlbum);
                });

            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    IdArtist = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameArtist = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ImageArtist = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Follower = table.Column<int>(type: "int", nullable: false),
                    Following = table.Column<int>(type: "int", nullable: false),
                    blueTick = table.Column<bool>(type: "bit", nullable: false),
                    Story = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthOfDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.IdArtist);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    IdCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCategory = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.IdCategory);
                });

            migrationBuilder.CreateTable(
                name: "Music",
                columns: table => new
                {
                    IdMusic = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameMusic = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LyrcsMusic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataMusic = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    DesriptionMusic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberLike = table.Column<int>(type: "int", nullable: false),
                    ImageMusic = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Music", x => x.IdMusic);
                });

            migrationBuilder.CreateTable(
                name: "SearchHistory",
                columns: table => new
                {
                    IdSearchHistory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAccount = table.Column<int>(type: "int", nullable: false),
                    Search = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeSearch = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchHistory", x => x.IdSearchHistory);
                    table.ForeignKey(
                        name: "FK_SearchHistory_Account",
                        column: x => x.IdAccount,
                        principalTable: "Account",
                        principalColumn: "IdAccount",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountFollowArtist",
                columns: table => new
                {
                    IdAccountFollowArtist = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAccount = table.Column<int>(type: "int", nullable: false),
                    IdArtist = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountFollowArtist", x => x.IdAccountFollowArtist);
                    table.ForeignKey(
                        name: "FK_AccountFollowArtist_Account",
                        column: x => x.IdAccount,
                        principalTable: "Account",
                        principalColumn: "IdAccount",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountFollowArtist_Artist",
                        column: x => x.IdArtist,
                        principalTable: "Artist",
                        principalColumn: "IdArtist",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountListenMusic",
                columns: table => new
                {
                    IdAccountListenMusic = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAccount = table.Column<int>(type: "int", nullable: false),
                    IdMusic = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountListenMusic", x => x.IdAccountListenMusic);
                    table.ForeignKey(
                        name: "FK_AccountListenMusic_Account",
                        column: x => x.IdAccount,
                        principalTable: "Account",
                        principalColumn: "IdAccount",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountListenMusic_Music",
                        column: x => x.IdMusic,
                        principalTable: "Music",
                        principalColumn: "IdMusic",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlbumMusic",
                columns: table => new
                {
                    IdAlbumMusic = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAlbum = table.Column<int>(type: "int", nullable: false),
                    IdMusic = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumMusic", x => x.IdAlbumMusic);
                    table.ForeignKey(
                        name: "FK_AlbumMusic_Album",
                        column: x => x.IdAlbum,
                        principalTable: "Album",
                        principalColumn: "IdAlbum",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumMusic_Music",
                        column: x => x.IdMusic,
                        principalTable: "Music",
                        principalColumn: "IdMusic",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistMusic",
                columns: table => new
                {
                    IdArtistMusic = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdArtist = table.Column<int>(type: "int", nullable: false),
                    IdMusic = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistMusic", x => x.IdArtistMusic);
                    table.ForeignKey(
                        name: "FK_AccountListenMusic_Artist",
                        column: x => x.IdArtist,
                        principalTable: "Artist",
                        principalColumn: "IdArtist",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistMusic_Music",
                        column: x => x.IdMusic,
                        principalTable: "Music",
                        principalColumn: "IdMusic",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryMusic",
                columns: table => new
                {
                    IdCategoryMusic = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategory = table.Column<int>(type: "int", nullable: false),
                    IdMusic = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryMusic", x => x.IdCategoryMusic);
                    table.ForeignKey(
                        name: "FK_CategoryMusic_ACategory",
                        column: x => x.IdCategory,
                        principalTable: "Category",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryMusic_Music",
                        column: x => x.IdMusic,
                        principalTable: "Music",
                        principalColumn: "IdMusic",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_Username",
                table: "Account",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountFollowArtist_IdAccount",
                table: "AccountFollowArtist",
                column: "IdAccount");

            migrationBuilder.CreateIndex(
                name: "IX_AccountFollowArtist_IdArtist",
                table: "AccountFollowArtist",
                column: "IdArtist");

            migrationBuilder.CreateIndex(
                name: "IX_AccountListenMusic_IdAccount",
                table: "AccountListenMusic",
                column: "IdAccount");

            migrationBuilder.CreateIndex(
                name: "IX_AccountListenMusic_IdMusic",
                table: "AccountListenMusic",
                column: "IdMusic");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumMusic_IdAlbum",
                table: "AlbumMusic",
                column: "IdAlbum");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumMusic_IdMusic",
                table: "AlbumMusic",
                column: "IdMusic");

            migrationBuilder.CreateIndex(
                name: "IX_Artist_NameArtist",
                table: "Artist",
                column: "NameArtist",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArtistMusic_IdArtist",
                table: "ArtistMusic",
                column: "IdArtist");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistMusic_IdMusic",
                table: "ArtistMusic",
                column: "IdMusic");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryMusic_IdCategory",
                table: "CategoryMusic",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryMusic_IdMusic",
                table: "CategoryMusic",
                column: "IdMusic");

            migrationBuilder.CreateIndex(
                name: "IX_SearchHistory_IdAccount",
                table: "SearchHistory",
                column: "IdAccount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountFollowArtist");

            migrationBuilder.DropTable(
                name: "AccountListenMusic");

            migrationBuilder.DropTable(
                name: "AlbumMusic");

            migrationBuilder.DropTable(
                name: "ArtistMusic");

            migrationBuilder.DropTable(
                name: "CategoryMusic");

            migrationBuilder.DropTable(
                name: "SearchHistory");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Music");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
