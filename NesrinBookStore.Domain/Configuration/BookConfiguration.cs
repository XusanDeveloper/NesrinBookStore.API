using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NesrinBooks.API.DataAccess.Entities;

namespace NesrinBookStore.Domain.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Books>
    {
        public void Configure(EntityTypeBuilder<Books> builder)
        {
            builder.HasData
        (
            new Books
            {
                Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                Name = "Diqqat",
                Author = "Kel Nyuport",
                Price = "40 000",
                Rating = "4",
                Description = "Tavsiya etiladi."
            },
            new Books
            {
                Id = new Guid("{f50fb0cb-cfe7-4649-af66-8178ad69230a}"),
                Name = "Savdogarlar Ustozi",
                Author = "Ahadquli XolMuhammad O'g'li",
                Price = "30 000",
                Rating = "5",
                Description = "Albatt tavsiya etiladi."
            },
            new Books
            {
                Id = new Guid("{4fdb4eec-1015-41a2-aab2-cf765fedb868}"),
                Name = "Boy ota kambag'al ota",
                Author = "Robert Kiyosaki",
                Price = "40 000",
                Rating = "2",
                Description = "Tavsiya etilmaydi."
            },
            new Books
            {
                Id = new Guid("{9126aea5-cfa3-4e45-92da-be5ca57d3afe}"),
                Name = "Qalb iffati",
                Author = "Nomalum",
                Price = "40 000",
                Rating = "4",
                Description = "Tavsiya etiladi."
            },
            new Books
            {
                Id = new Guid("{71da79e2-fecd-4e4b-bdca-40e7d6b1f421}"),
                Name = "Baxtiyor Oila",
                Author = "Muhammad Yusuf Muhammad Sodiq",
                Price = "60 000",
                Rating = "5",
                Description = "Albatta tavsiya etiladi."
            },
            new Books
            {
                Id = new Guid("{7178347d-1cc5-4b67-80e2-13e27f295c7a}"),
                Name = "Ijyimoiy odoblar",
                Author = "Muhammad Yusuf Muhammad Sodiq",
                Price = "50 000",
                Rating = "5",
                Description = "Albatt tavsiya etiladi."
            }
        );
        }
    }
}
